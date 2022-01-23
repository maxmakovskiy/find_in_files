using Xunit;

namespace phrase_finder.tests {

public class PathFinderTests
{
    [Fact]
    public void TestSearch()
    {
        string fileName = "/home/xemerius/devs/find_in_files/tests/rsc/file1.txt";
        string phrase = "users and services access";
        var finder = new PhraseFinder(fileName, phrase);
        var result = finder.Search();
        
        LineInfo info = new LineInfo();
        info.fileName = fileName;
        info.wholeLine = "or deny users and services access to system resources.";
        info.lineNumber = 16;

        Assert.Equal(System.Tuple.Create(info, FinderStatus.FOUND), result);

    }

}

}