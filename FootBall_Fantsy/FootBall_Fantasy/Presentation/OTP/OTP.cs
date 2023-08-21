using FootBall_Fantasy.Business.OTP;
using FootBall_Fantasy.Business.ResponseClass;
using FootBall_Fantasy.Business.SignUp;
using FootBall_Fantasy.Business.Users;
using FootBall_Fantasy.Data_Access.DataAccessTempUser;
using Newtonsoft.Json;

namespace FootBall_Fantasy.Presentation.OTP;

public static class OTP
{
    public class VerifySignUpOTPAPIFields
    {
        public string Email { get; set; } = string.Empty;
        public string OTP { get; set; } = string.Empty;
    }
    public static async Task VerifySignUpOTPAPI(HttpContext context)
    {
        var requestBody = context.Request.Body;
        var requestBodyString = await new StreamReader(requestBody).ReadToEndAsync();
        var requestBodyObject = JsonConvert.DeserializeObject<VerifySignUpOTPAPIFields>(requestBodyString);


        var response = new Response();

        if (requestBodyObject == null) 
        {
            response.Success = false;
            response.Message = string.Empty;
        }
        else
        {
            response = OtpHandler.VerifyOtp(requestBodyObject.Email, requestBodyObject.OTP);
            if (response.Success)
            {
                TempUserHandler.VerifyUser(requestBodyObject.Email);
            }
        }
        

        var responseJson = JsonConvert.SerializeObject(response);

        context.Response.StatusCode = 200;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(responseJson);

    }
}

