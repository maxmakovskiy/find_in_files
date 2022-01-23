using System.Text.RegularExpressions;

namespace phrase_finder {

public enum FinderStatus {
    FOUND, NOT_FOUND
}

public struct LineInfo 
{
    public int lineNumber;
    public string wholeLine;
    public string fileName;
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

    public Tuple<LineInfo, FinderStatus> Search()
    {
        LineInfo info = new LineInfo();
        FinderStatus status = FinderStatus.NOT_FOUND;

        for (int i = 0; i < content.Length; ++i)
        {
            if (FindSubstring(content[i])) 
            {
                info.lineNumber = i+1;
                info.wholeLine = content[i];
                info.fileName = fileName;
                status = FinderStatus.FOUND;
            }
        }

        return Tuple.Create(info, status);
    }

}


}