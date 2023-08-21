using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace FootBall_Fantasy.Business.OTP;
internal static class OtpGenerator
{
    private static string Key = "123Untitled321";
    private static byte[] KeyBytes = Encoding.UTF8.GetBytes(Key);
    public static string Generate()
    {
        HMACSHA256 hmac = new HMACSHA256(KeyBytes);
        byte[] randomBytes = new byte[3];
        RandomNumberGenerator.Fill(randomBytes);
        byte[] hashedBytes = hmac.ComputeHash(randomBytes);
        int otp = Math.Abs(BitConverter.ToInt32(hashedBytes, 0) % 900000 + 100000);
        return otp.ToString("D6");
    }
}
public class OtpRecord
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public DateTime SentTime { get; set; }

    public string Otp { get; set; }

    public bool IsExpired { get; set; }
    public OtpRecord(string Email)
    {
        this.Email = Email;
        SentTime = DateTime.Now;
        Otp = OtpGenerator.Generate();
        IsExpired = false;
    }
}
