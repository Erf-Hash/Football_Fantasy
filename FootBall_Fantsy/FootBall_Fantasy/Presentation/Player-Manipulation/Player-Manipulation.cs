using FootBall_Fantasy.Business.ResetPassword;
using FootBall_Fantasy.Business.ResponseClass;
using Newtonsoft.Json;
using FootBall_Fantasy.Business.Players;

namespace FootBall_Fantasy.Presentation.Player_Manipulation;

public class Player_Manipulation
{

    public static async Task GetManipulatedPlayers(HttpContext context)
    {
        var requestBody = context.Request.Body;
        var requestBodyString = await new StreamReader(requestBody).ReadToEndAsync();
        var requestBodyObject = JsonConvert.DeserializeObject<PlayersManipulation>(requestBodyString);

        var responseJson = JsonConvert.SerializeObject(requestBodyObject.GetManipulatedPlayers());
        context.Response.StatusCode = 200;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(responseJson);
    }
}
