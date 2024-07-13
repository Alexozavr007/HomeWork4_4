using System.Reflection;
using System.Text.RegularExpressions;

namespace HomeWork4_4_6;

public class RegistrationForm {
    [FormRegex(Regex = @"^[a-zA-Z]+$")]
    public string Login { get; set; }

    [FormRegex(Regex = @"^[a-zA-Z0-9]+$")]
    public string Password { get; set; }

    private bool ValidateByRegex(string regex, string value) {
        var reg = new Regex(regex);
        return reg.IsMatch(value);
    }

    public bool ValidateLogin() {
        var pInfo = typeof(RegistrationForm).GetProperty(nameof(Login)).GetCustomAttribute<FormRegexAttribute>();
        return ValidateByRegex(pInfo.Regex, Login);
    }

    public bool ValidatePassword() {
        var pInfo = typeof(RegistrationForm).GetProperty(nameof(Password)).GetCustomAttribute<FormRegexAttribute>();
        return ValidateByRegex(pInfo.Regex, Password);
    }
}
