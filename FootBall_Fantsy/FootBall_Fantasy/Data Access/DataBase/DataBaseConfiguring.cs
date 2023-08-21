using FootBall_Fantasy.Business.OTP;
using FootBall_Fantasy.Business.Users;
using FootBall_Fantasy.Business.ResetPassword;
using Microsoft.EntityFrameworkCore;
using FootBall_Fantasy.Business.Players;
using FootBall_Fantasy.Business.Teams;

namespace FootBall_Fantasy.Data_Access;

public class DataBaseConfiguring : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<OtpRecord> OtpRecord { get; set; }
    public DbSet<TempUser> tempUser { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<FPLTeams> teams { get; set; }
    public DbSet<UserPlayer> userPlayers { get; set; }
    private static string FileName = "FootBall_FantasyDB.db";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source = {FileName}");
    }
}
