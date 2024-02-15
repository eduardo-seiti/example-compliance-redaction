using ComplianceRedaction.Api.Endpoints;
using ComplianceRedaction.Application;
using ComplianceRedaction.Application.Logging;
using Microsoft.Extensions.Compliance.Classification;
using Microsoft.Extensions.Compliance.Redaction;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole(options => options.JsonWriterOptions = new JsonWriterOptions
{
    Indented = true
});
builder.Logging.EnableRedaction();

builder.Services.AddRedaction(x =>
{
    x.SetRedactor<StarRedactor>(new DataClassificationSet(DataTaxonomy.PiiData));
    x.SetHmacRedactor(options =>
    {
        options.Key = Convert.ToBase64String("StringRepresentationSecretKeyJustForDemo"u8);
        options.KeyId = 99;
    }, new DataClassificationSet(DataTaxonomy.SensitiveData));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();

var app = builder.Build();

app.AddCustomerEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();