using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace LoggerTests;


[TestClass]
public class LoggerTests
{

    private string docPath = Path.Combine(Logger.docPath, "application.log");


    /// <summary>
    /// Test initialization method. Executes before each test to set up the test environment.
    /// Deletes the log file if it exists before running a test.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        if (File.Exists(docPath))
        {
            File.Delete(docPath);
        }
    }

    /// <summary>
    /// Test verifying whether the LogMessage method correctly writes a message to a file.
    /// </summary>IsLogMessageBeenWrittenCorrectly
    [TestMethod]
    public void IsLogMessageBeenWrittenCorrectly()
    {
        string testMessage = "Test message";
        string testSeverity = "INFO";

        Logger.LogMessage(testSeverity, testMessage);

        Assert.IsTrue(File.Exists(docPath)); 

        string[] lines = File.ReadAllLines(docPath);
        Assert.AreEqual(1, lines.Length); 

        string lastLine = lines[0];
        Assert.IsTrue(lastLine.Contains(testMessage)); 
        Assert.IsTrue(lastLine.Contains($"[{testSeverity}]"));
    }

    /// <summary>
    /// Test verifying if messages are saved correctly.
    /// </summary>
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

    /// <summary>
    /// Test verifying the correctness of severity levels returned by the method.
    /// </summary>
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

    /// <summary>
    /// Test verifying the correctness of messages returned by the method.
    /// </summary>
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