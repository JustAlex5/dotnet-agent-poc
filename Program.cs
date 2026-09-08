using AgentAiDemo.API.Agent;
using AgentAiDemo.API.Bl;
using AgentAiDemo.API.Bl.Interface;
using AgentAiDemo.API.Configurations;
using AgentAiDemo.API.Dal;
using AgentAiDemo.API.Dal.Interface;
using AgentAiDemo.API.Data;
using AgentAiDemo.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using OllamaSharp;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<ICompanyDal, CompanyDal>();
builder.Services.AddScoped<ICompanyBl, CompanyBl>();

builder.Services.AddScoped<CompanyTools>();
builder.Services.AddScoped<CompanyAgent>();

builder.Services.AddMemoryCache();

builder.Services.AddSingleton<IConversationStore, MemoryConversationStore>();
var providerRaw =
    builder.Configuration["AI:Provider"]
    ?? throw new InvalidOperationException("AI provider is missing.");

if (!Enum.TryParse<AgentProvider>(
        providerRaw,
        ignoreCase: true,
        out var provider))
{
    throw new InvalidOperationException(
        $"Unsupported AI provider: {providerRaw}");
}
switch (provider)
{
    case AgentProvider.OpenAi:
    {
        var apiKey =
            builder.Configuration["OpenAI:ApiKey"]
            ?? throw new InvalidOperationException("OpenAI API key missing.");

        var model =
            builder.Configuration["OpenAI:Model"]
            ?? throw new InvalidOperationException("OpenAI model missing.");

        var openAiClient = new OpenAIClient(apiKey);

        builder.Services
            .AddChatClient(
                openAiClient
                    .GetChatClient(model)
                    .AsIChatClient())
            .UseFunctionInvocation();

        break;
    }

    case AgentProvider.Ollama:
    {
        var endpoint =
            builder.Configuration["Ollama:Endpoint"]
            ?? "http://127.0.0.1:11434";

        var model =
            builder.Configuration["Ollama:Model"]
            ?? throw new InvalidOperationException("Ollama model missing.");

        var ollamaClient = new OllamaApiClient(
            new Uri(endpoint),
            model);

        builder.Services
            .AddChatClient(ollamaClient)
            .UseFunctionInvocation();

        break;
    }

    default:
        throw new ArgumentOutOfRangeException(
            nameof(provider),
            provider,
            null);
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();