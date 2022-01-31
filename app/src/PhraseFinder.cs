using System.Text.RegularExpressions;

namespace phrase_finder {

public struct LineInfo 
{
    public int LineNumber;
    public string WholeLine;
    public string Filename;
}

public class PhraseFinder
{
    private readonly string[] _filenames;
    private readonly string _targetPhrase;

    public PhraseFinder(string source, string targetPhrase)
    {
        var tempFilenames = new List<string>();
        if (File.Exists(source)) {
            tempFilenames.Add(source);
        } else {
            foreach (var filename in Directory.GetFiles(source))
            {
                tempFilenames.Add(filename);
            }
        }
        
        _filenames = tempFilenames.ToArray();
        _targetPhrase = targetPhrase;
    }

    private bool FindSubstring(string source)
    {
        string pattern = ".*(" + _targetPhrase + ").*";
        return Regex.IsMatch(source, pattern);
    }

    public LineInfo[] Search()
    {
        var result = new List<LineInfo>();
        foreach (var file in _filenames)
        {
            foreach (var res in SearchInSingleFile(file))
            {
                result.Add(res);    
            }
        }

        return result.ToArray();
    }
    
    private LineInfo[] SearchInSingleFile(string filename)
    {
        string[] content = File.ReadAllLines(filename);
        var infos = new List<LineInfo>();

        for (int i = 0; i < content.Length; ++i)
        {
            if (FindSubstring(content[i])) 
            {
                var info = new LineInfo {
                    LineNumber = i+1,
                    WholeLine = content[i],
                    Filename = filename
                };
                infos.Add(info);
            }
        }

        return infos.ToArray();
    }
 
}


}