using Xunit;

namespace phase_finder.tests {

public class OptionsTest
{

    [Theory]
    [InlineData(new object[] { new string[] {"-source",  "folder",  "-phrase", "hello"} })]
    [InlineData(new object[] { new string[] {"-source", "file", "-phrase", "hello", "world"} })]
    public void TestIsValidOptions_ReturnTrue(string[] args)
    {
        Assert.True(Options.IsValidOptions(args));
    }

    [Theory]
    [InlineData(new object[] { new string[] {"-source",  "",  "-phrase", "hello"} })]
    [InlineData(new object[] { new string[] {"-source", "file", "-phrase", ""} })]
    [InlineData(new object[] { new string[] {"", "file", "-phrase", "world"} })]
    [InlineData(new object[] { new string[] {"-source", "file", "", "world"} })]
    [InlineData(new object[] { new string[] {"", "file", "", "world"} })]
    [InlineData(new object[] { new string[] {"", "file", "", ""} })]
    [InlineData(new object[] { new string[] {"", "", "", ""} })]
    [InlineData(new object[] { new string[] {""} })]
    public void TestIsValidOptions_ReturnFalse(string[] args)
    {
        Assert.False(Options.IsValidOptions(args));
    }


}

}



