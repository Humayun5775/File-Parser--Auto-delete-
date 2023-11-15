using FileParser;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "Codewrinles Services";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<FileParser.FileParser>();
    })
    .Build();

await host.RunAsync();
