using HomeWork4_4_6;
using System.Text;
using System.Text.RegularExpressions;

Console.OutputEncoding = Encoding.Unicode;
var form = new RegistrationForm();
bool again = true;
//var regLogin = new Regex(@"^[a-zA-Z]+$");
//var regPass = new Regex(@"^[a-zA-Z0-9]+$");

var _default = Console.ForegroundColor;
Console.ForegroundColor = ConsoleColor.Yellow;
Console.SetCursorPosition(45, 0);
Console.WriteLine("Реєстрація нового користувача");
Console.ForegroundColor= _default;

while (again) {
    Console.SetCursorPosition(30, 5);
    Console.Write("Введіть логін: ");
    form.Login = Console.ReadLine();

    if (form.ValidateLogin()) {        
        again = false;
        Console.SetCursorPosition(30, 7);
        Console.Write(new string(' ', 84));
    } else {
        Console.SetCursorPosition(30, 7);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Введене значення некоректне. Допускаються лише символи англійського алфавіту");
        Console.ForegroundColor = _default;
        again = true;

        Console.SetCursorPosition(30, 5);
        Console.Write(new string (' ', 80));
    }
}

again = true;
while (again) {
    Console.SetCursorPosition(30, 9);
    Console.Write("Введіть пароль: ");
    form.Password =  Console.ReadLine();

    if (form.ValidatePassword()) {
        again = false;
        Console.SetCursorPosition(30, 13);
        Console.Write(new string(' ', 84));
    } else {
        Console.SetCursorPosition(30, 13);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Введене значення некоректне. Допускаються лише символи англійського алфавіту та цифр");
        Console.ForegroundColor = _default;
        again = true;

        Console.SetCursorPosition(30, 9);
        Console.Write(new string(' ', 80));
    }
}

Console.SetCursorPosition(30, 13);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Акк успішно створено");
Console.ForegroundColor = _default;

// form