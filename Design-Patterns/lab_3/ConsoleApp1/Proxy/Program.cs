using Proxy;
using System.Text.RegularExpressions;

var smartTextReader = new SmartTextReader();
var checker = new SmartTextCheker(smartTextReader);


checker.OpenFile("./test.txt");
checker.GetFileContent();
checker.CloseFile();

Console.WriteLine();


var checkerWithSecurity = new TextLocker(checker, new Regex("secure[.]txt$"));


try
{
    Console.WriteLine("Testing with security.");
    checkerWithSecurity.OpenFile("./secure.txt");
    checkerWithSecurity.GetFileContent();
    checkerWithSecurity.CloseFile();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

