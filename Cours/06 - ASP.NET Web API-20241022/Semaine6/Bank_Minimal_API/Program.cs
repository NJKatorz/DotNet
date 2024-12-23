var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

double CalculTVA(double price, string country)
{
    if(country.Equals("FR"))
        return price * 1.20;
    if (country.Equals("BE"))
        return price * 1.21;
    return price;
}

app.MapGet("/tva", (double price, string country) =>
{
    double totalPrice = CalculTVA(price, country);
    if (totalPrice == price)
        return $"Invalid country code. Please use 'BE' or 'FR'.";
    if (country.Equals("BE"))
        return $"price: {price}, country: {country} -> {totalPrice} (TVA Belgique 21%)";
    return $"price: {price}, country: {country} -> {totalPrice} (TVA France 20%)";
})
.WithName("GetTva")
.WithOpenApi();


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
