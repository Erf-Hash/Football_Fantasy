using FootBall_Fantasy.Data_Access.ChangeUserInfo;
using FootBall_Fantasy.Business.JWT;
using FootBall_Fantasy.Business.ResponseClass;
using FootBall_Fantasy.Business.Users;
using FootBall_Fantasy.Data_Access.DataAccessUser;
using Newtonsoft.Json;
using static FootBall_Fantasy.Presentation.SignUp.SignUp;

namespace FootBall_Fantasy.Presentation.UserInformation
{
    public class UserInformation
    {
        public static float GetCash(string Token)
        {
            User? user = DataAccessUser.GetUserById(JWT.ValidateToken(Token));
            if (user == null)
            {
                return -1f;
            }
            return user.Cash;
        }
        public static object GetInfo(string Token)
        {
            User? user = DataAccessUser.GetUserById(JWT.ValidateToken(Token));
            var response = new Response();

            if (user == null)
            {
                response.Success = false;
                response.Message = "user was not found!";
                return new
                {
                    Success = response.Success,
                    Message = response.Message
                };
            }
            else
            {
                object userPublicData = new
                {
                    Success = true,
                    Message = "user found successfuly",
                    Name = user.Name,
                    UserName = user.UserName,
                    Email = user.Email
                };
                return userPublicData;
            }
        }
        public class ChangeInformationFields
        {
            public enum InfoType
            {
                UserName,
                Name,
                Password
            }
            public InfoType info;
            public string? CurrentPassword { get; set; }
            public string? NewValue { get; set; }
        }
        public static async Task ChangeInformation(HttpContext context)
        {
            //Header
            var requestHeaderString = context.Request.Headers.FirstOrDefault(x => x.Key == "Authentication").Value.ToString();
            User? user = DataAccessUser.GetUserById(JWT.ValidateToken(requestHeaderString));
            //Body
            var requestBody = context.Request.Body;
            var requestBodyString = await new StreamReader(requestBody).ReadToEndAsync();
            var requestBodyObject = JsonConvert.DeserializeObject<ChangeInformationFields>(requestBodyString);

            var response = new Response();

            if (user == null)
            {
                response.Success = false;
                response.Message = "user was not found!";
            }
            else
            {
                if (requestBodyObject == null)
                {
                    response.Success = false;
                    response.Message = string.Empty;
                }
                else
                {
                    if (user.Password != requestBodyObject.CurrentPassword) 
                    {
                        response.Success = false;
                        response.Message = "password was not correct!";
                    }
                    else if (requestBodyObject.NewValue == null)
                    {
                        response.Success = false;
                        response.Message = "New value is null!";
                    }
                    else
                    {
                        switch (requestBodyObject.info)
                        {
                            case ChangeInformationFields.InfoType.Password:
                                response = ChangeUserInfoClass.ChangePassword(user, requestBodyObject.NewValue);
                                break;
                            case ChangeInformationFields.InfoType.UserName:
                                response = ChangeUserInfoClass.ChangeUsername(user, requestBodyObject.NewValue);
                                break;
                            case ChangeInformationFields.InfoType.Name:
                                response = ChangeUserInfoClass.ChangeName(user, requestBodyObject.NewValue);
                                break;
                        }
                    }
                }
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 200;
            var responseJson = JsonConvert.SerializeObject(response);
            await context.Response.WriteAsync(responseJson);
        }
    }
}
