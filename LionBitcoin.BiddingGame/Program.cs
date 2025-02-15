using LionBitcoin.BiddingGame;
using LionBitcoin.BiddingGame.Application;
using LionBitcoin.BiddingGame.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi("docs");

builder.Services
    .AddApplication(builder.Configuration)
    .AddPersistence();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/docs.json", "LionBitcoin.BiddingGame");
});

app.UseMiddleware<MetadataFillerMiddleware>();

app.MapControllers();

app.ApplyMigrations();
app.Run();