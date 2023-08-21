using FootBall_Fantasy.Business.JWT;
using FootBall_Fantasy.Business.Login;
using FootBall_Fantasy.Business.ResetPassword;
using FootBall_Fantasy.Business.ResponseClass;
using FootBall_Fantasy.Business.Users;
using FootBall_Fantasy.Data_Access.DataAccessUser;
using Newtonsoft.Json;

namespace FootBall_Fantasy.Presentation.Login;
public static class Login
{
    public class LoginAPIFields
    {
        public string userOrEmail { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
    public static async Task LoginAPI(HttpContext context)
    {
        var requestBody = context.Request.Body;
        var requestBodyString = await new StreamReader(requestBody).ReadToEndAsync();
        var requestBodyObject = JsonConvert.DeserializeObject<LoginAPIFields>(requestBodyString);


        var response = new Response();

        string GeneratedToken = string.Empty;
        if (requestBodyObject == null) 
        {
            response.Success = false;
            response.Message = string.Empty;
        }
        else if (Business.Login.Login.CheckCredential(requestBodyObject.userOrEmail, requestBodyObject.password))
        {
            User user = DataAccessUser.GetUserByUserOrEmail(requestBodyObject.userOrEmail);
            GeneratedToken = JWT.GenerateToken(user);
            response.Success = true;
            response.Message = GeneratedToken;
            context.Response.Cookies.Append("Authentication", GeneratedToken);
        }
        else
        {
            response.Success = false;
            response.Message = "User or password is not correct.";
        }

        var responseJson = JsonConvert.SerializeObject(response);

        // Send Response
        context.Response.StatusCode = 200;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(responseJson);
    }
}

