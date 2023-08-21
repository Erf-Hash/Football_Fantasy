using FootBall_Fantasy.Business.JWT;
using FootBall_Fantasy.Business.ResetPassword;
using FootBall_Fantasy.Business.ResponseClass;
using FootBall_Fantasy.Business.Users;
using FootBall_Fantasy.Data_Access.DataAccessUser;
using Newtonsoft.Json;

namespace FootBall_Fantasy.Presentation.ResetPassword;

public static class ResetPasswordPresentation
{
    public class ResetPassVerifyAPIFields
    {
        public string Email { get; set; } = string.Empty;
        public string RecievedKey { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
    public static object ResetPassRequestAPI(string email)
    {
        var response = new Response();
        if (DataAccessUser.GetUserByUserOrEmail(email) == null)
        {
            response.Success = false;
            response.Message = "user was not found!";
            return response;
        }
        return ResetPass.NewResetPassRequest(email);
    }
    public static async Task ResetPassVerifyAPI(HttpContext context)
    {
        //Body
        var requestBody = context.Request.Body;
        var requestBodyString = await new StreamReader(requestBody).ReadToEndAsync();

        var requestBodyObject = JsonConvert.DeserializeObject<ResetPassVerifyAPIFields>(requestBodyString);


        var response = new Response();

        
        if (requestBodyObject == null)
        {
            response.Success = false;
            response.Message = string.Empty;
        }
        if (DataAccessUser.GetUserByUserOrEmail(requestBodyObject.Email) == null)
        {
            response.Success = false;
            response.Message = "user was not found!";
        }
        else
        {
            response = ResetPass.VerifyResetPassRequest(requestBodyObject.Email, requestBodyObject.RecievedKey, requestBodyObject.NewPassword);
        }
        var responseJson = JsonConvert.SerializeObject(response);

        // Send Response
        context.Response.StatusCode = 200;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(responseJson);
    }
}

