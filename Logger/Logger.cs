/*
Task 1: Logger

Context: Your team is working on a project where you need to log various events and errors.
You are asked to create a simple logging function that writes messages to a text file with a timestamp.

Example usage:

log_message("application.log", "User logged in", "INFO")
log_message("application.log", "Failed login attempt", "WARNING")

Expected Output in application.log:

[2023-04-24 12:34:56] [INFO] User logged in
[2023-04-24 12:35:10] [WARNING] Failed login attempt
 */


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