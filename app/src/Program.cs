
namespace phrase_finder {

public class Program
{
    public static void Main(string[] args)
    {
        if (!Options.IsValidOptions(args)) {
            Console.WriteLine("wrong format of command line arguments");
            Console.WriteLine("correct format: -source /path/to/file -phrase hello world phrase");
        } else {
            var options = Options.Parse(args);
            FinderManager finderManager = new FinderManager(options);
            Console.WriteLine(finderManager.GetResult());
        }
    }
}

}