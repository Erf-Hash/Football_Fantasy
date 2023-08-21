namespace FootBall_Fantasy.Business.Asynchronous_Methods;
public class Asynchronous_Methods
{
    private const int Hour = 3600000;
    private const int Minute = 60000;

    public static async void AsynchronouslyUpdating()
    {
        TempUserOtpUpdating();
        PlayerUpdating();
    }
    private static async void TempUserOtpUpdating()
    {
        while (true)
        {
            Data_Access.DataAccessTempUser.DataAccessTempUser.Update();
            Data_Access.OTP.DataAccessOTP.UpdateTable();



            await Task.Delay(24 * Hour);
        }
    }
    private static async void PlayerUpdating()
    {
        while (true)
        {
            Data_Access.DataAccessPlayer.DataAccessPlayer.UpdatePlayers();
            Data_Access.DataAccessTeam.DataAccessFPLTeam.UpdateTeams();
            Data_Access.DataAccessUser.DataAccessUser.UpdateUserScores();
            Data_Access.DataAccessUserPlayer.DataAccessUserPlayer.ClearTable();

            await Task.Delay(168 * Hour);
        }
    }
}