using System.Text.RegularExpressions;

namespace phrase_finder {

public struct CmdOptions 
{
    public string phrase;
    public string source;

    public CmdOptions(string source, string phrase)
    {
        this.source = source;
        this.phrase = phrase;
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
        options.source = inputs[1];
        options.phrase = String.Join(' ', inputs.Skip(3).ToArray());

        return options;
    }

}

}