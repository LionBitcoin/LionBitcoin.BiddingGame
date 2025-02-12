using LionBitcoin.BiddingGame;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddApplication(builder.Configuration)
    .AddPersistence();

var app = builder.Build();

app.UseSwaggerUI();

app.UseMiddleware<MetadataFillerMiddleware>();

app.MapControllers();

app.Run();