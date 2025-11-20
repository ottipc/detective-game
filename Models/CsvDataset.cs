using Postgrest.Attributes;
using Postgrest.Models;

namespace Detektivspiel.Models;

[Table("csv_datasets")]
public class CsvDataset : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("name")]
    public string Name { get; set; } = "";

    [Column("description")]
    public string? Description { get; set; }

    [Column("headers")]
    public List<string> Headers { get; set; } = new();

    [Column("data")]
    public List<Dictionary<string, string>> Data { get; set; } = new();

    [Column("uploader_name")]
    public string? UploaderName { get; set; }

    [Column("download_count")]
    public int DownloadCount { get; set; }
}
