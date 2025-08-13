using MauiAppFit.Helpers;

namespace MauiAppFit
{
    public partial class App : Application
    {
        static SQLiteDataBaseHelper database;

        public static SQLiteDataBaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteDataBaseHelper(
                        Path.Combine(Enviroment.GetFolderPath(
                            Enviroment.SpecialFolder.LocalApplicationData),
                            "XamAppFit.db3"));
                }

                return database;
            }
        }
    }
}