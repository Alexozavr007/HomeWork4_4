using HomeWork4_4_4;
using System.Globalization;
using System.Text;
   
Console.OutputEncoding = Encoding.Unicode;
Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA");

var fileCheck = FileCheck.ReadFile("TestCheck.txt");

Console.WriteLine("Чек в локалі користувача (ua):");
Console.WriteLine(new string('=', 30));
fileCheck.DisplayToConsole();

Console.WriteLine("\r\nЧек в локалі en-US:");
Console.WriteLine(new string('=', 30));
fileCheck.DisplayToConsole("en-US");