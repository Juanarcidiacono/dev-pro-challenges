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

    [TestMethod]
    public void IsTheReturnOfSeverityLevelsCorrect()
    {
        List<string> predefinedLevels = new List<string>
         { 
            "DEBUG",
            "INFO",
            "WARNING",
            "ERROR",
            "CRITICAL"
        };

        string severity = Logger.SeverityLevels();

        Assert.IsTrue(predefinedLevels.Contains(severity));
    }


    [TestMethod]
    public void IsTheReturnOfMessagesCorrect()
    {
        List<string> predefinedMessages = new List<string>
        {
            "User logged in",
            "Failed login attempt",
            "Connection established",
            "Data saved successfully",
            "Error: Invalid input",
            "Logout successful"
        };

        string severity = Logger.Messages();

        Assert.IsTrue(predefinedMessages.Contains(severity));
    }


}

