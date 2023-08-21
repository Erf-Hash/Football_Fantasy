using FootBall_Fantasy.Business.ResponseClass;
using FootBall_Fantasy.Business.SignUp;
using FootBall_Fantasy.Business.Users;
using FootBall_Fantasy.Data_Access;

namespace FootBall_Fantasy.Data_Access.ChangeUserInfo;//needs work validation required

public class ChangeUserInfoClass
{
    public static Response ChangePassword(User user, string NewPassword)
    {
        var response = new Response();
        using (var DB = new DataBaseConfiguring())
        {
            if (DB.users.FirstOrDefault(x => x.id == user.id) == null)
            {
                response.Success = false;
                response.Message = "user not found";
                return response;
            }
            var validationResponse = BusinessSignUp.SignUpValidation(user.Email, user.Name, user.UserName, NewPassword, BusinessSignUp.ValidationType.JustPassword);
            if (!validationResponse.Success)
            {
                return validationResponse;
            }
            DB.users.First(x => x.id == user.id).Password = NewPassword;
            DB.SaveChanges();
            response.Success = true;
            response.Message = "Password has been changed successfuly.";
        }
        return response;
    }
    public static Response ChangeUsername(User user, string NewUsername)
    {
        var response = new Response();
        using (var DB = new DataBaseConfiguring())
        {
            if (DB.users.FirstOrDefault(x => x.id == user.id) == null)
            {
                response.Success = false;
                response.Message = "user not found";
                return response;
            }
            var validationResponse = BusinessSignUp.SignUpValidation(user.Email, user.Name, NewUsername, user.Password, BusinessSignUp.ValidationType.JustUserName);
            if (!validationResponse.Success)
            {
                return validationResponse;
            }
            DB.users.First(x => x.id == user.id).UserName = NewUsername;
            DB.SaveChanges();
            response.Success = true;
            response.Message = "UserName has been changed successfuly.";
        }
        return response;
    }
    public static Response ChangeName(User user, string NewName)
    {
        var response = new Response();
        using (var DB = new DataBaseConfiguring())
        {
            if (DB.users.FirstOrDefault(x => x.id == user.id) == null)
            {
                response.Success = false;
                response.Message = "user not found";
                return response;
            }
            var validationResponse = BusinessSignUp.SignUpValidation(user.Email, NewName, user.UserName, user.Password, BusinessSignUp.ValidationType.JustName);
            if (!validationResponse.Success)
            {
                return validationResponse;
            }
            DB.users.First(x => x.id == user.id).Name = NewName;
            DB.SaveChanges();
            response.Success = true;
            response.Message = "Name has been changed successfuly.";
        }
        return response;
    }
}
