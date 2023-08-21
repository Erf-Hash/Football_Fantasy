using FootBall_Fantasy.Presentation.FPLTeams;
using FootBall_Fantasy.Presentation.Login;
using FootBall_Fantasy.Presentation.OTP;
using FootBall_Fantasy.Presentation.Player_Manipulation;
using FootBall_Fantasy.Presentation.Ranking;
using FootBall_Fantasy.Presentation.ResetPassword;
using FootBall_Fantasy.Presentation.SignUp;
using FootBall_Fantasy.Presentation.TeamManage;
using FootBall_Fantasy.Presentation.UserInformation;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(options => { options.AddDefaultPolicy(builder => { builder.WithOrigins("http://localhost:*").AllowAnyHeader().AllowAnyMethod(); }); });
        var app = builder.Build();
        app.UseCors(builder =>
        {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
        app.Use((context, next) =>
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            return next();
        });

        FootBall_Fantasy.Business.Asynchronous_Methods.Asynchronous_Methods.AsynchronouslyUpdating();

        //APIs
        app.MapPost("/SignUp/", SignUp.SignUpAPI);
        app.MapPost("/SignUp/OTP/", OTP.VerifySignUpOTPAPI);
        app.MapPost("/Login/", Login.LoginAPI);
        app.MapGet("/Login/ResetPasswordRequest/", ResetPasswordPresentation.ResetPassRequestAPI);
        app.MapPost("/Login/ResetPasswordVerify/", ResetPasswordPresentation.ResetPassVerifyAPI);
        app.MapPost("/EditTeam/", TeamManage.Edit);
        app.MapPost("/User/ChangeInfo", UserInformation.ChangeInformation);
        app.MapGet("/User/Info", UserInformation.GetInfo);
        app.MapGet("/User/Cash", UserInformation.GetCash);
        app.MapPost("/GetFPLPlayers/", Player_Manipulation.GetManipulatedPlayers);
        app.MapPost("/EditTeam/Get", TeamManage.Get);
        app.MapGet("/Ranking/", Ranking.ShowRanking);
        app.MapGet("/GetFPLTeams/", Teams.GetFPLTeams);

        app.Run("http://localhost:5432");

    }
}
