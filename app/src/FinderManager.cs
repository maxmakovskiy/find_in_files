
namespace phrase_finder {

public class FinderManager
{
    private readonly PhraseFinder _phraseFinder;
    private readonly string _phrase;

    public FinderManager(CmdOptions options)
    {
        _phrase = options.Phrase;  
        _phraseFinder = new PhraseFinder(options.Source, options.Phrase);
    }

    public string GetResult()
    {
        var resultOfFind = _phraseFinder.Search();
        if (resultOfFind.Length == 0) {
            return "not found";
        }

        string result = $"Phrase '{_phrase}' was found in:\n";
        foreach (var info in resultOfFind) {
            result +=
                $"- file'{info.Filename}' at string #{info.LineNumber}: '{info.WholeLine}'\n";
        }
        return result;
    }

}

}