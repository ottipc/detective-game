using Supabase;
using Detektivspiel.Models;

namespace Detektivspiel.Services;

public class SupabaseService
{
    private readonly Client _client;

    public SupabaseService()
    {
        var url = "https://lhjhuikviddfrhmofdlh.supabase.co";
        var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imxoamh1aWt2aWRkZmZobW90ZGxoIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjM1OTIyOTgsImV4cCI6MjA3OTE2ODI5OH0.B5-FvgXJ18m9jtfXp6Zy8NT1zBKbfMV0L9j1qEEBFvk";
        
        _client = new Client(url, key, new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = false
        });
    }

    public async Task InitializeAsync()
    {
        await _client.InitializeAsync();
    }

    public async Task<List<CsvDataset>> GetDatasetsAsync()
    {
        var response = await _client
            .From<CsvDataset>()
            .Order("created_at", Postgrest.Constants.Ordering.Descending)
            .Get();
        
        return response.Models;
    }

    public async Task<CsvDataset?> SaveDatasetAsync(string name, string? description, List<string> headers, List<Dictionary<string, string>> data, string? uploaderName)
    {
        var dataset = new CsvDataset
        {
            Name = name,
            Description = description,
            Headers = headers,
            Data = data,
            UploaderName = uploaderName
        };

        var response = await _client
            .From<CsvDataset>()
            .Insert(dataset);

        return response.Models.FirstOrDefault();
    }

    public async Task IncrementDownloadCountAsync(Guid id)
    {
        var dataset = await _client
            .From<CsvDataset>()
            .Where(x => x.Id == id)
            .Single();

        if (dataset != null)
        {
            dataset.DownloadCount++;
            await dataset.Update<CsvDataset>();
        }
    }
}
