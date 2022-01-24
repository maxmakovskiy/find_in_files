
namespace phrase_finder {

public class FinderManager
{
    private PhraseFinder phraseFinder;
    private string phrase;

    public FinderManager(CmdOptions options)
    {
        phrase = options.phrase;  
        phraseFinder = new PhraseFinder(options.source, options.phrase);
    }

    public string GetResult()
    {
        var resultOfFind = phraseFinder.Search();
        if (resultOfFind.Item2 == FinderStatus.NOT_FOUND) {
            return "not found in " + resultOfFind.Item1.fileName;
        }

        string result = String.Format("Phare {0} was found in:\n- file\"{1}\" at string {2}: {3}", 
            phrase, resultOfFind.Item1.fileName, resultOfFind.Item1.lineNumber, resultOfFind.Item1.wholeLine);

        return result;
    }

}

}