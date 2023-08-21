using FootBall_Fantasy.Data_Access.SignUp;
using System.Text.RegularExpressions;

namespace FootBall_Fantasy.Business.SignUp;

public static class Validation
{
    public static bool EmptyField(string str)
    {
        return str == "" ? true : false;
    }

    public static bool HasCorrectLength(string str, int MinLength, int MaxLength)
    {
        return str.Length <= MaxLength && str.Length >= MinLength ? true : false;
    }
}
public static class PasswordValidation
{
    public static int MinLength { get; set; }
    public static int MaxLength { get; set; }
    static PasswordValidation()
    {
        MinLength = 8;
        MaxLength = 32;
    }
    public static bool EmptyField(string str) => Validation.EmptyField(str);
    public static bool HasCorrectLength(string str) => Validation.HasCorrectLength(str, MinLength, MaxLength);
    public static bool ContainsPersonalInformation(string password, string name, string username, string email)
    {
        return Regex.IsMatch(password, @$"{name}+")
            || Regex.IsMatch(password, @$"{username}+")
            || Regex.IsMatch(password, @$"{email}");
    }
    public static bool IsPredictablePattern(string password)
    {
        return Regex.IsMatch(password, @"\b\w*?(\w)\1{4,}\w*\b");
    }
    public static bool HasAnyUpperCase(string password)
    {
        return Regex.IsMatch(password, @"([A-Z])+");
    }
    public static bool HasAnyLowerCase(string password)
    {
        return Regex.IsMatch(password, @"([a-z])+");
    }
    public static bool HasAnyNumber(string password)
    {
        return Regex.IsMatch(password, @"(\d)+");
    }
    public static bool HasAnySymbol(string password)
    {
        return Regex.IsMatch(password, @"[\W_]");
    }
}
public static class NameValidation
{
    public static int MinLength { get; set; }
    public static int MaxLength { get; set; }
    static NameValidation()
    {
        MinLength = 2;
        MaxLength = 50;
    }
    public static bool EmptyField(string str) => Validation.EmptyField(str);
    public static bool HasCorrectLength(string str) => Validation.HasCorrectLength(str, MinLength, MaxLength);
}
public static class UserNameValidation
{
    public static int MinLength { get; set; }
    public static int MaxLength { get; set; }
    static UserNameValidation()
    {
        MinLength = 4;
        MaxLength = 20;
    }
    public static bool EmptyField(string str) => Validation.EmptyField(str);
    public static bool HasCorrectLength(string str) => Validation.HasCorrectLength(str, MinLength, MaxLength);
    public static bool IsValidFormat(string username)
    {
        return Regex.IsMatch(username, @"^(?=.*[a-zA-Z])[a-zA-Z0-9_.-]+$");
    }
    public static bool IsDuplicated(string username)
    {

        if (DataAccessSignUp.FindRecord(username) != null)
        {
            return true;
        }
        return false;
    }
}
public static class EmailValidation
{
    public static int MinLength { get; set; }
    public static int MaxLength { get; set; }
    static EmailValidation()
    {
        MinLength = 3;
        MaxLength = 320;
    }
    public static bool EmptyField(string str) => Validation.EmptyField(str);
    public static bool HasCorrectLength(string str) => Validation.HasCorrectLength(str, MinLength, MaxLength);
    public static bool IsValidFormat(string email)
    {
        return Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
    }
    public static bool IsDuplicated(string email)
    {
        if (DataAccessSignUp.FindRecord(email) != null)
        {
            return true;
        }
        return false;
    }
}


