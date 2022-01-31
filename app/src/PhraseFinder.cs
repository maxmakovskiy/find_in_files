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
    private string[] content;
    private string fileName;
    private string targetPhrase;

    public PhraseFinder(string fileName, string targetPhrase)
    {
        this.fileName = fileName;
        this.targetPhrase = targetPhrase;
        content = File.ReadAllLines(fileName);
    }

    private bool FindSubstring(string source)
    {
        string pattern = ".*(" + targetPhrase + ").*";
        return Regex.IsMatch(source, pattern);
    }

    public LineInfo[] Search()
    {
        var infos = new List<LineInfo>();

        for (int i = 0; i < content.Length; ++i)
        {
            if (FindSubstring(content[i])) 
            {
                var info = new LineInfo {
                    LineNumber = i+1,
                    WholeLine = content[i],
                    Filename = fileName
                };
                infos.Add(info);
            }
        }

        return infos.ToArray();
    }

}


}