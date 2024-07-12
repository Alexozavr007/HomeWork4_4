using System.Text;
using System.Text.RegularExpressions;

Console.OutputEncoding = Encoding.Unicode;
Console.WriteLine("Введіть URL: ");
var url = Console.ReadLine();

using HttpClient client = new HttpClient();
string html = await client.GetStringAsync(url);

var links = new List<string>();
var emails = new List<string>();
var phones = new List<string>();

var regLinks = new Regex(@"[""'](?'link'http[^""']+)");
/* test values:
<link rel="preconnect" href='https://fonts.googleapis.com'>
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin> 
<link rel="preload" href="https://fonts.googleapis.com/css2?family=Open+Sans:ital,wght@0,300;0,400;0,600;0,700;1,400&family=Source+Code+Pro:wght@400;500;700&display=swap" as="style" onload="this.onload=null;this.rel='stylesheet'"> 
<link href="http://google.com" rel="home" />
 */

var regEmails = new Regex(@"[""':> ](?'email'\w+@\w+\.+\w+[^""'< ]+)");
/* test values:
Mail us to '213123@weqwe.com'
test@rewr.com bla bla bla
<b>test2@erwerwwe.com</b>
<a href="mailto:mm@gmail.com">click me</a>
 */

var regPhones = new Regex("(?'phone'(\\+3\\s?)?(\\(\\d{3,4}\\)|\\d{3,4})\\s?[0-9\\-\\s]{7,9})");
/* test values:
Kyivstar (097) 644-99-33
<b>(097) 644-99-33</b>
<b>(097) 644-9933</b>
<b>(097)644-99-33</b>
<b>(097)6449933</b>
<b>097 6449933</b>
<b>0976449933</b>
<b>+380976449933</b>
за номером +3 8095 751 08 88
 */

if (!regLinks.IsMatch(html) && !regEmails.IsMatch(html) && !regPhones.IsMatch(html)) {
    Console.WriteLine("Сторінка не містить посилань/ном.телефонів/пошт.адрес");
} else {
    // collect HTML items
    foreach (Match item in regLinks.Matches(html)) {
        links.Add(item.Groups["link"].Value);
    }
    foreach(Match item in regEmails.Matches(html)) {
        emails.Add(item.Groups["email"].Value);
    }
    foreach (Match item in regPhones.Matches(html)) {
        phones.Add(item.Groups["phone"].Value);
    }

    // save into file
    var file = File.Create("File.txt");
    StreamWriter writer = new StreamWriter(file);
    writer.WriteLine("Links:");
    foreach (var link in links) {
        writer.WriteLine(link);
    }
    writer.WriteLine("Emails:");
    foreach (var email in emails) {
        writer.WriteLine(email);
    }
    writer.WriteLine("Phones:");
    foreach (var phone in phones) {
        writer.WriteLine(phone);
    }

    writer.Close();
}
