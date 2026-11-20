using KafkaLabWork9;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<OrderService>();

var host = builder.Build();
host.Run();
