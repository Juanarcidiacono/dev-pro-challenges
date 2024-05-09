using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

public class Logger
{
    public static string docPath { get; } = AppDomain.CurrentDomain.BaseDirectory;
   
    static void Main(string[] args)
    {
        Console.WriteLine("Log entry");

        LogMessage(SeverityLevels(), Messages());

    }


    /// <summary>
    /// Generates a random log message from a predefined list of messages.
    /// </summary>
    /// <returns>A randomly selected log message.</returns>
    public static string Messages()
    {
        List<string> messages = new List<string>
        {
            "User logged in",
            "Failed login attempt",
            "Connection established",
            "Data saved successfully",
            "Error: Invalid input",
            "Logout successful"
        };

        return messages[new Random().Next(0, messages.Count)]; ;
    }

    /// <summary>
    /// Generates a random severity level from a predefined list of levels.
    /// </summary>
    /// <returns>A randomly selected severity level.</returns>
    public static string SeverityLevels()
    {
        List<string> severityLevels = new List<string>
        {
            "DEBUG",
            "INFO",
            "WARNING",
            "ERROR",
            "CRITICAL"

        };

        return severityLevels[new Random().Next(0, severityLevels.Count)]; ;
    }

    /// <summary>
    /// Logs a message with the specified level and content to a log file.
    /// </summary>
    /// <param name="level">The severity level of the log message.</param>
    /// <param name="message">The content of the log message.</param>
    public static void LogMessage(string level, string message)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string logEntry = $"[{timestamp}] [{level}] {message}";



        try
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "application.log"), true))

            {
                outputFile.WriteLine(logEntry);
                Console.WriteLine(logEntry);
                Console.WriteLine(Path.Combine(docPath, "application.log"));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to log file: {ex.Message}");
        }
    }


}
