using System.Text.RegularExpressions;

namespace phase_finder {

public struct CmdOptions 
{
    public string phrase;
    public string source;
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

        return options;
    }

}

}