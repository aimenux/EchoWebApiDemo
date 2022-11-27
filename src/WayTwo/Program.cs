using WayTwo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IEchoService, EchoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app
    .MapGet("/echo", (IEchoService service, CancellationToken cancellationToken) => service.GetEchoResponseAsync(cancellationToken))
    .WithName("GetEchoResponse");

app.Run();