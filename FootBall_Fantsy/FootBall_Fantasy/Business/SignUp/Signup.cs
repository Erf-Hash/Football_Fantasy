using FootBall_Fantasy.Business.ResponseClass;

namespace FootBall_Fantasy.Business.SignUp
{
    public static class BusinessSignUp
    {
        public enum ValidationType
        {
            Any,
            JustEmail,
            JustName,
            JustUserName,
            JustPassword
        }
        public static Response SignUpValidation(string email, string name, string username, string password, ValidationType validationType = ValidationType.Any)
        {
            Response response;
            string message = "";
            bool Success = true;
            if (validationType == ValidationType.JustPassword || validationType == ValidationType.Any)
            {
                if (!PasswordValidation.HasCorrectLength(password))
                {
                    message += "the length of password is out of range.\n";
                    Success = false;
                }

                if (!PasswordValidation.HasAnyNumber(password))
                {
                    message += "the password doesnt have any number.\n";
                    Success = false;
                }

                if (!PasswordValidation.HasAnySymbol(password))
                {
                    message += "the password doesnt have any symbol.\n";
                    Success = false;
                }

                if (!PasswordValidation.HasAnyUpperCase(password))
                {
                    message += "the password doesnt have any upperCase.\n";
                    Success = false;
                }

                if (!PasswordValidation.HasAnyLowerCase(password))
                {
                    message += "the password doesnt have any lowerCase\n";
                    Success = false;
                }

                if (PasswordValidation.IsPredictablePattern(password))
                {
                    message += "the password is a predictable pattern\n";
                    Success = false;
                }

                if (PasswordValidation.EmptyField(name))
                {
                    message += "the password is empty.\n";
                    Success = false;
                }
            }
            if (validationType == ValidationType.JustName || validationType == ValidationType.Any)
            {
                if (NameValidation.EmptyField(name))
                {
                    message += "the name is empty.\n";
                    Success = false;
                }

                if (!NameValidation.HasCorrectLength(name))
                {
                    message += "the name length is out of range.\n";
                    Success = false;
                }
            }
            if (validationType == ValidationType.JustUserName || validationType == ValidationType.Any)
            {
                if (!UserNameValidation.IsValidFormat(username))
                {
                    message += "the username is not valid form.\n";
                    Success = false;
                }

                if (UserNameValidation.EmptyField(name))
                {
                    message += "the username is empty.\n";
                    Success = false;
                }

                if (!UserNameValidation.HasCorrectLength(name))
                {
                    message += "the username length is out of range.\n";
                    Success = false;
                }

                if (UserNameValidation.IsDuplicated(username))
                {
                    message += "the username is duplicate.\n";
                    Success = false;
                }
            }
            if (validationType == ValidationType.JustEmail || validationType == ValidationType.Any)
            {
                if (!EmailValidation.IsValidFormat(email))
                {
                    message += "the email is not valid form.\n";
                    Success = false;
                }

                if (EmailValidation.EmptyField(name))
                {
                    message += "the email is empty.\n";
                    Success = false;
                }

                if (EmailValidation.IsDuplicated(email))
                {
                    message += "the email is duplicate.\n";
                    Success = false;
                }

                if (!EmailValidation.HasCorrectLength(name))
                {
                    message += "the email length is out of range.\n";
                    Success = false;
                }
                if (Success)
                {
                    message += "Signup is successfuly.\n";
                }
            }
            response = new Response(Success, message);
            return response;
        }
    }
}
