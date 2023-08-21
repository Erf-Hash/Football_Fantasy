using FootBall_Fantasy.Business.Email;
using FootBall_Fantasy.Data_Access.OTP;
using FootBall_Fantasy.Data_Access;
using FootBall_Fantasy.Business.ResponseClass;

namespace FootBall_Fantasy.Business.OTP;

public class OtpHandler
{
    public static Response NewOtp(string Email)
    {
        OtpRecord newRecord = new OtpRecord(Email);
        DataAccessOTP.AddRecord(newRecord);
        return SendOtpEmail(Email, newRecord.Otp);
    }
    private static Response SendOtpEmail(string Email, string Otp)
    {
        string subject = "Otp code";
        string body = $"hi\nuse the verification code.\n{Otp}";
        return EmailSender.SendEmail(Email, subject, body);
    }
    public static Response VerifyOtp(string Email, string OtpReceived)
    {
        DateTime currentTime = DateTime.Now;
        DateTime ExpireTime = currentTime.AddMinutes(-10);
        Response verifyResult;
        var record = DataAccessOTP.GetRecord(Email);
        if (record == null)
        {
            verifyResult = new Response(false , "No such email has been registered");
        }
        else if (record.SentTime <= ExpireTime)
        {
            verifyResult = new Response(false, "Otp is expired,Try again");
        }
        else if (record.Otp != OtpReceived)
        {
            verifyResult = new Response(false, "Wrong code,Try again");
        }
        else
        {
            verifyResult = new Response(true, "Successful signup, Welcome to Football fantasy");
            DataAccessOTP.RemoveRecord(record);
        }
        return verifyResult;
    }
}

