using System.Text.RegularExpressions;

namespace phrase_finder {

public struct CmdOptions 
{
    public string Phrase;
    public string Source;

    public CmdOptions(string source, string phrase)
    {
        Source = source;
        Phrase = phrase;
    }
}

public static class Options {
    public static bool IsValidOptions(string[] inputs)
    {
        string pattern = "(-source (\\w|\\S)+ -phrase .+)";
        string whole = String.Join(' ', inputs);
        return Regex.IsMatch(whole, pattern);
    }

    public static CmdOptions Parse(string[] inputs)
    {
        CmdOptions options = new CmdOptions();
        options.Source = inputs[1];
        options.Phrase = String.Join(' ', inputs.Skip(3).ToArray());

        return options;
    }
    
}

}