using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace LoggerTests;


[TestClass]
public class LoggerTests
{
    [TestMethod]
    public void IsMessageSavedCorrectly()
    {
        string docPath = Path.Combine(Logger.docPath, "application.log");
        string testMessage = "Test message";
        string testSeverity = "INFO";


        Logger.LogMessage(testSeverity, testMessage);

        string[] lines = File.ReadAllLines(docPath);
        string lastLine = lines[lines.Length - 1];

        Assert.IsTrue(lastLine.Contains($"[{testSeverity}] {testMessage}"));
    }
}
