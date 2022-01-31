using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Xunit;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

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
    
    [Fact]
    public void TestFoundMultiOccurrencesSingleFile()
    {
        string source = GetRootPath() + "/rsc/file3.txt";
        string phrase = "access";
        var finder = new PhraseFinder(source, phrase);
        var result = finder.Search();

        var expected = new LineInfo[] {
            new LineInfo() {
                LineNumber = 14,
                WholeLine = "Users and groups are a mechanism for access control;",
                Filename = source,
            },
            new LineInfo() {
                LineNumber = 16,
                WholeLine = "or deny users and services access to system resources.",
                Filename = source
            },
        };
        
         Assert.Equal(result.Length, expected.Length);
         Assert.Equal(expected, result);
    }

    [Fact]
    public void TestSearchSingleInSeveralFiles()
    {
         string source = GetRootPath() + "/rsc/several";
         string phrase = "of";
         var finder = new PhraseFinder(source, phrase);
         var result = finder.Search();
         var expected = new LineInfo[] {
            new LineInfo() {
                LineNumber = 1,
                WholeLine = "Arch Linux Code of Conduct",
                Filename = source + "/file1.txt",
            },
            new LineInfo() {
                LineNumber = 7,
                WholeLine = "The code of conduct here has been developed over a number of years and reflects the community’s ethos",
                Filename = source + "/file1.txt"
            },
            new LineInfo() {
                LineNumber = 8,
                WholeLine = "of a functional support system with a high signal-to-noise ratio and an explicit expectation of self-sufficiency,",
                Filename = source + "/file1.txt"
            },
            new LineInfo() {
                 LineNumber = 11,
                 WholeLine = "and an effective way of making your initial interactions with other Arch Linux users mutually beneficial.",
                 Filename = source + "/file1.txt"
            },
            new LineInfo() {
                   LineNumber = 15,
                   WholeLine = "themselves or encroaching on the freedom of others. Embracing these principles and obeying ",
                   Filename = source + "/file1.txt"
            },
            new LineInfo() {
                   LineNumber = 17,
                   WholeLine = "and other oppressive, harmful and negative consequences of a more chaotic approach.",
                   Filename = source + "/file1.txt"
            },
            new LineInfo() {
                LineNumber = 7,
                WholeLine = "are charged with the responsibility of maintaining peaceful, civil order for the",
                Filename = source + "/file2.txt"
            },
            new LineInfo() {
                LineNumber = 8,
                WholeLine = "majority of the community. Therefore, they cannot always please everyone with the decisions made.",
                Filename = source + "/file2.txt"
            },
            new LineInfo() {
                LineNumber = 5,
                WholeLine = "self awareness and remain peaceable toward their peers. Taking responsibility for our actions is often",
                Filename = source + "/file3.txt"
            }, 
         };
      
         Assert.NotEmpty(result); 
         Assert.Equal(result.Length, expected.Length);
         Assert.Equal(result, expected);
    }

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