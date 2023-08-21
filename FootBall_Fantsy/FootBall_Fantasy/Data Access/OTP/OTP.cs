using FootBall_Fantasy.Business.OTP;

namespace FootBall_Fantasy.Data_Access.OTP;
public class DataAccessOTP
{
    public static void UpdateTable()
    {
        DateTime currentTime = DateTime.Now;
        DateTime deletionTime = currentTime.AddDays(-1);
        using (var DB = new DataBaseConfiguring())
        {
            var recordsToDelete = DB.OtpRecord.Where(x => x.SentTime <= deletionTime).ToList();
            DB.OtpRecord.RemoveRange(recordsToDelete);
            DB.SaveChanges();
        }
    }
    public static void AddRecord(OtpRecord newRecord)
    {
        using (var DB = new DataBaseConfiguring())
        {
            var PreviousOtp = DB.OtpRecord.FirstOrDefault(x => x.Email == newRecord.Email && x.IsExpired == false);
            if (PreviousOtp != null)
            {
                PreviousOtp.IsExpired = true;
            }
            DB.OtpRecord.Add(newRecord);
            DB.SaveChanges();
        }
    }
    public static OtpRecord? GetRecord(string Email)
    {
        using (var DB = new DataBaseConfiguring())
        {
            var Records = DB.OtpRecord.Where(x => x.Email == Email);
            if (Records.Any(x => x.IsExpired == false))
            {
                return DB.OtpRecord.First(x => x.Email == Email && x.IsExpired == false);
            }
            return DB.OtpRecord.FirstOrDefault(x => x.Email == Email);
        }
    }
    public static void RemoveRecord(OtpRecord DeletingRecord)
    {
        using (var DB = new DataBaseConfiguring())
        {
            DB.OtpRecord.Remove(DeletingRecord);
            DB.SaveChanges();
        }
    }
}
