using FootBall_Fantasy.Business.OTP;
using FootBall_Fantasy.Business.ResponseClass;
using FootBall_Fantasy.Business.SignUp;
using FootBall_Fantasy.Business.Users;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace FootBall_Fantasy.Presentation.SignUp;

public static class SignUp
{
    public class SignUpAPIFields
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
    public static async Task SignUpAPI(HttpContext context)
    {
        var requestBody = context.Request.Body;
        var requestBodyString = await new StreamReader(requestBody).ReadToEndAsync();
        var requestBodyObject = JsonConvert.DeserializeObject<SignUpAPIFields>(requestBodyString);

        var response = new Response();

        if (requestBodyObject == null)
        {
            response.Success = false;
            response.Message = "user was null!";
        }
        else
        {
            response = BusinessSignUp.SignUpValidation(requestBodyObject.Email, requestBodyObject.Name, requestBodyObject.UserName, requestBodyObject.Password);
            if (response.Success)
            {
                var tempUser = new TempUser(requestBodyObject.Name, requestBodyObject.Email, requestBodyObject.Password, requestBodyObject.UserName);
                TempUserHandler.AddTempUser(tempUser);
                OtpHandler.NewOtp(requestBodyObject.Email);
            }
        }
        var responseJson = JsonConvert.SerializeObject(response);

        context.Response.StatusCode = 200;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(responseJson);
    }
}
