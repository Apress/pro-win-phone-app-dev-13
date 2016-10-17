using System.Data.Linq.Mapping;

namespace LocalDatabase.Classes
{
[Table]
public class Juice
{
    [Column(IsPrimaryKey = true,
        IsDbGenerated = true,
        DbType = "INT NOT NULL Identity",
        CanBeNull = false)]
    public int Id { get; set; }
    [Column]
    public string Name { get; set; }
    [Column]
    public string Description { get; set; }
}
}
