using Xunit;

namespace phrase_finder.tests {

public class PathFinderTests
{
    [Fact]
    public void TestSearchFoundOfSingleOccurrences()
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

    [Fact]
    public void TestSearchNotFound()
    {
        string fileName = "/home/xemerius/devs/find_in_files/tests/rsc/file1.txt";
        string phrase = "this is a sample string";
        var finder = new PhraseFinder(fileName, phrase);
        var result = finder.Search();
        
        LineInfo info = new LineInfo();

        Assert.Equal(System.Tuple.Create(info, FinderStatus.NOT_FOUND), result);
    }

    [Fact]
    public void TestSearchInEmptyFile()
    {
        string fileName = "/home/xemerius/devs/find_in_files/tests/rsc/file2.txt";
        string phrase = "target string";
        var finder = new PhraseFinder(fileName, phrase);
        var result = finder.Search();
        
        LineInfo info = new LineInfo();

        Assert.Equal(System.Tuple.Create(info, FinderStatus.NOT_FOUND), result);
    }

}

}