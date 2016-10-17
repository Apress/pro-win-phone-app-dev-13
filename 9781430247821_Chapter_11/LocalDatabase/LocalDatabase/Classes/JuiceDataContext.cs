using System.Data.Linq;

namespace LocalDatabase.Classes
{
public class JuiceDataContext : DataContext
{
    public const string ConnectionString = @"Data Source=isostore:/Juice.sdf";

    public JuiceDataContext(string connectionString)
        : base(connectionString) { }

    public Table<Juice> Juices;
}
}
