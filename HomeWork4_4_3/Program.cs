using System.Text.RegularExpressions;

var reg = new Regex(@"(?'preposition'(для|про|до|від|біля|на){1}\s\w*)");
var textFromFile = File.ReadAllText("Test.txt");

if (reg.IsMatch(textFromFile)) {
    textFromFile = reg.Replace(textFromFile, "ГАВ!");
    File.WriteAllText("Test MODIFIED.txt", textFromFile);
}