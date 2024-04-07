using Adapter;
using System.IO;

void TestLogger(ILogger logger)
{
    logger.Log("Test log.");
    logger.Warn("Test warn.");
    logger.Error("Test error.");
}

TestLogger(new Logger());

if (Directory.Exists("./Logs") == false)
    Directory.CreateDirectory("./Logs");

TestLogger(new FileLogger(new FileWriter("./Logs/testlog.txt")));
