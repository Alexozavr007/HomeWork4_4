using System.Text.RegularExpressions;

namespace HomeWork4_4_4;

public class FileCheck {
    public List<FileCheckLine> Lines { get; set; }
    public DateTime Time { get; set; }

    public void DisplayToConsole(string? locale = null) {
        if (locale == null) {
            Console.WriteLine($"Time: {Time}");
            foreach (var item in Lines) {
                Console.WriteLine($"{item.Product}:\t{item.Price.ToString("C")}");
            }
        } else {
            var culture = System.Globalization.CultureInfo.CreateSpecificCulture(locale);
            Console.WriteLine($"Time: {Time.ToString(culture)}");
            foreach (var item in Lines) {
                Console.WriteLine($"{item.Product}:\t{item.Price.ToString("C", culture)}");
            }
        }
    }

    public static FileCheck ReadFile(string filePath) {
        var retObj = new FileCheck { 
            Lines = new List<FileCheckLine>()
        };

        var fileStream = File.OpenRead(filePath);
        var reader = new StreamReader(fileStream);
        var line = reader.ReadLine();
        var regLine = new Regex(@"^(?'product'[\w\s]*) - (?'price'[\d,]+)грн");
        var regDateTime = new Regex(@"(?'date'\d{1,2} \w{3} \d{4} \d{1,2}:\d{2})");
        //var pointChar = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        var culture = System.Globalization.CultureInfo.CreateSpecificCulture("uk-UA");

        while (line != null) {
            if (regLine.IsMatch(line)) {
                var m = regLine.Match(line);
                retObj.Lines.Add(new FileCheckLine { 
                    Product = m.Groups["product"].Value,
                    Price = Convert.ToSingle(m.Groups["price"].Value, culture)
                    //Price = Convert.ToSingle(m.Groups["price"].Value.Replace(",", pointChar))
                });
            } else if (regDateTime.IsMatch(line)) {
                var m = regDateTime.Match(line);
                var stringDate = m.Groups["date"].Value;

                DateTime date;
                if (DateTime.TryParseExact(stringDate, "d MMM yyyy HH:mm", culture, System.Globalization.DateTimeStyles.None, out date)) {
                    retObj.Time = date;
                }
            }

            line = reader.ReadLine();
        }
        reader.Close();

        return retObj;
    }

}
