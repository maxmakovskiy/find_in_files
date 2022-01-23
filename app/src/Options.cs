using System.Text.RegularExpressions;

namespace phase_finder {

public struct CmdOptions 
{
    public string phrase;
    public string source;

    public CmdOptions(string phrase, string source)
    {
        this.phrase = phrase;
        this.source = source;
    }
}

public static class Options {
    public static bool IsValidOptions(string[] inputs)
    {
        string pattern = "(-source \\w+ -phrase .+)";
        string whole = String.Join(' ', inputs);
        return Regex.IsMatch(whole, pattern);
    }

    public static CmdOptions Parse(string[] inputs)
    {
        CmdOptions options = new CmdOptions();
        options.phrase = inputs[1];
        options.source = String.Join(' ', inputs.Skip(3).ToArray());

        return options;
    }

}

}