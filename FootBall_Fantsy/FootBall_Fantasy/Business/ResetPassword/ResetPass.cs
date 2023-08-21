using FootBall_Fantasy.Business.Email;
using FootBall_Fantasy.Business.Users;
using FootBall_Fantasy.Presentation.OTP;
using FootBall_Fantasy.Business.OTP;
using System.ComponentModel.DataAnnotations;
using FootBall_Fantasy.Data_Access;
using FootBall_Fantasy.Business.CallAPI;
using System.ComponentModel;
using FootBall_Fantasy.Data_Access.ChangeUserInfo;
using FootBall_Fantasy.Business.ResponseClass;

namespace FootBall_Fantasy.Business.ResetPassword;

public class ResetPass
{
    public static Response NewResetPassRequest(string Email) => OtpHandler.NewOtp(Email);

    public static Response VerifyResetPassRequest(string Email, string ReceivedKey, string NewPassword)
    {
        using (var DB = new DataBaseConfiguring())
        {
            var userThatRequested = DB.OtpRecord.FirstOrDefault(x => x.Email == Email);
            if (userThatRequested == null)
            {
                return new Response(false , "No such email has been registered");
            }
            else if (userThatRequested.IsExpired)
            {
                return new Response(false, "Key is expired,Try again");
            }
            else if (userThatRequested.Otp != ReceivedKey)
            {
                return new Response(false, "Wrong code");
            }
            else
            { 
                var TargetUser = DB.users.FirstOrDefault(x => x.Email.Equals(userThatRequested.Email));
                var response = ChangeUserInfoClass.ChangePassword(TargetUser, NewPassword);
                DB.OtpRecord.Remove(userThatRequested);
                DB.SaveChanges();
                return response;
            }
        }
    }
}
