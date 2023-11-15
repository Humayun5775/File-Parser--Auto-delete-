namespace FileParser
{
    public class FileParser : BackgroundService
    {
        private readonly ILogger<FileParser> _logger;
        private const string _folderpath = @"D:\parser";


        public FileParser(ILogger<FileParser> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //await Task.Delay(1000, stoppingToken);
                foreach(var file in Directory.EnumerateFiles(_folderpath))
                {
                    _logger.LogInformation("processing {Filename}", file);
                    var filepath = Path.Combine(_folderpath, file);
                    File.Delete(filepath);
                    _logger.LogInformation("Proccessing finished, the file {filename} was deleted");
                }
            }
        }
    }
}