using Microsoft.Phone.Data.Linq; 

namespace LocalDatabase.Classes
{
public class JuiceDB
{

    private const int DatabaseVersion = 2;

    public static void InitializeLocalDatabase()
    {
        using (JuiceDataContext context = new JuiceDataContext(JuiceDataContext.ConnectionString))
        {
            if (!context.DatabaseExists())
            {
                context.CreateDatabase();

                // set version here, still works when
                // a new database is created with a later version
                var updater = context.CreateDatabaseSchemaUpdater();
                updater.DatabaseSchemaVersion = DatabaseVersion;
                updater.Execute();
            }
            else
            {
                var updater = context.CreateDatabaseSchemaUpdater();

                if (updater.DatabaseSchemaVersion < 2)
                {
                    updater.AddColumn<Juice>("JuiceDescription");
                }
                updater.DatabaseSchemaVersion = DatabaseVersion;
                updater.Execute();
            }
        }
    }
}
}
