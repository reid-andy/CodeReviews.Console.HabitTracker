using static DBChecker;

public class Program
{
    public static void Main(string[] args)
    {
        DBChecker dbChecker = new DBChecker();
        dbChecker.InitializeDB();
        dbChecker.SeedDB();
    }
}