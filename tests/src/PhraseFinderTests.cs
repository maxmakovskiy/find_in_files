using System.IO;
using Xunit;

namespace phrase_finder.tests {

public class PathFinderTests
{
    private static string GetRootPath()
    {
        return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    }

    [Fact]
    public void TestSearchFoundOfSingleOccurrences()
    {
        string source = GetRootPath() + "/rsc/file1.txt";
        string phrase = "users and services access";
        var finder = new PhraseFinder(source, phrase);
        var result = finder.Search();
        
        var info = new LineInfo();
        info.Filename = source;
        info.WholeLine = "or deny users and services access to system resources.";
        info.LineNumber = 16;

        Assert.Single(result);
        Assert.Equal(new LineInfo[] {info}, result);
    }
    
/*
    [Fact]
    public void TestFoundMultiOccurrencesSingleFile()
    {
        string source = GetRootPath() + "/rsc/file3.txt";
        string phrase = "it via SSH on a server";
        var finder = new PhraseFinder(source, phrase);
        var result = finder.Search();
    }
    */

    [Fact]
    public void TestSearchNotFound()
    {
        string fileName = GetRootPath() + "/rsc/file1.txt";
        string phrase = "this is a sample string";
        var finder = new PhraseFinder(fileName, phrase);
        var result = finder.Search();
        
        LineInfo info = new LineInfo();

        Assert.Empty(result);
    }

    [Fact]
    public void TestSearchInEmptyFile()
    {
        string fileName = GetRootPath() + "/rsc/file2.txt";
        string phrase = "target string";
        var finder = new PhraseFinder(fileName, phrase);
        var result = finder.Search();
        
        LineInfo info = new LineInfo();

        Assert.Empty(result);
    }

}

}