using FootBall_Fantasy.Business.Users;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootBall_Fantasy.Data_Access.DataAccessTempUser;

public class DataAccessTempUser
{
    public static void Erase()
    {
        using (var DB = new DataBaseConfiguring())
        {
            var allRecord = DB.tempUser.ToList();
            DB.tempUser.RemoveRange(allRecord);
            DB.SaveChanges();
        }
    }
    public static void AddRecord(TempUser tempUser)
    {
        using (var DB = new DataBaseConfiguring())
        {
            var previousTemp = DB.tempUser.FirstOrDefault(x => x.Email == tempUser.Email);
            if ( previousTemp != null)
            {
                DB.tempUser.Remove(previousTemp);
            }
            DB.tempUser.Add(tempUser);
            DB.SaveChanges();
        }
    }
    public static TempUser? FindByEmail(string email)
    {
        using (var DB = new DataBaseConfiguring())
        {
            var tempUser = DB.tempUser.FirstOrDefault(x => x.Email == email);
            return tempUser;
        }
    }
    public static void Update()
    {
        using (var DB = new DataBaseConfiguring())
        {
            var DeletationRecords = DB.tempUser.Where(x => x.BuildTime < DateTime.Now.AddDays(-1)).ToList();
            DB.tempUser.RemoveRange(DeletationRecords);
            DB.SaveChanges();
        }
    }
    public static bool MoveToUserTable(TempUser tempUser)
    {
        using(var DB = new DataBaseConfiguring())
        {
            var record = DB.tempUser.FirstOrDefault(x => x.Email == tempUser.Email);
            if (record != null )
            {
                DB.tempUser.Remove(record);
                DataAccessUser.DataAccessUser.AddRecord(new User(tempUser));
                DB.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
