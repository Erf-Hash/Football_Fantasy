using FootBall_Fantasy.Business.JWT;
using FootBall_Fantasy.Business.Players;
using FootBall_Fantasy.Business.ResetPassword;
using FootBall_Fantasy.Business.ResponseClass;
using FootBall_Fantasy.Business.Users;
using FootBall_Fantasy.Data_Access.DataAccessUser;
using Newtonsoft.Json;

namespace FootBall_Fantasy.Presentation.TeamManage
{
    public class TeamManage
    {
        public enum Action
        {
            Add,
            Remove,
            Substitution
        }
        public class EditFields
        {
            public Action Action;
            public int id_1 { get; set; }
            public int id_2 { get; set; }
        }
        public static async Task Edit(HttpContext context)
        {
            //Header
            var requestHeaderString = context.Request.Headers.FirstOrDefault(x => x.Key == "Authentication").Value.ToString();
            User? user = DataAccessUser.GetUserById(JWT.ValidateToken(requestHeaderString));
            //Body
            var requestBody = context.Request.Body;
            var requestBodyString = await new StreamReader(requestBody).ReadToEndAsync();
            var requestBodyObject = JsonConvert.DeserializeObject<EditFields>(requestBodyString);
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
                    var team = new UserTeam(user.Cash, user.id);
                    switch (requestBodyObject.Action)
                    {
                        case Action.Add:
                            response = team.Add(requestBodyObject.id_1);
                            break;
                        case Action.Remove:
                            response = team.Remove(requestBodyObject.id_1);
                            break;
                        case Action.Substitution:
                            response = team.Substitution(requestBodyObject.id_1, requestBodyObject.id_2);
                            break;
                    }
                    user.Cash = team.Cash;
                    DataAccessUser.UpdateCash(user);
                }
            }

            var responseJson = JsonConvert.SerializeObject(response);

            // Send Response
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(responseJson);
        }
        public class GetFields
        {
            public enum GetType
            {
                Any,
                Fixed,
                Substitutes
            }
            public GetType Type { get; set; }
            public Filter.Position Position { get; set; }
        }
        public static async Task Get(HttpContext context)
        {
            //Header
            var requestHeaderString = context.Request.Headers.FirstOrDefault(x => x.Key == "Authentication").Value.ToString();
            User? user = DataAccessUser.GetUserById(JWT.ValidateToken(requestHeaderString));
            //Body
            var requestBody = context.Request.Body;
            var requestBodyString = await new StreamReader(requestBody).ReadToEndAsync();
            var requestBodyObject = JsonConvert.DeserializeObject<GetFields>(requestBodyString);

            context.Response.ContentType = "application/json";
            var response = new Response();

            if (user == null)
            {
                response.Success = false;
                response.Message = "user was not found!";
                context.Response.StatusCode = 200;
                var responseJson = JsonConvert.SerializeObject(response);
                await context.Response.WriteAsync(responseJson);
            }
            else
            {
                if (requestBodyObject == null)
                {
                    response.Success = false;
                    response.Message = string.Empty;
                    context.Response.StatusCode = 200;
                    var responseJson = JsonConvert.SerializeObject(response);
                    await context.Response.WriteAsync(responseJson);
                }
                else
                {
                    List<Player?> list = new List<Player?>();
                    var team = new UserTeam(user.Cash ,user.id);
                    switch (requestBodyObject.Type)
                    {
                        case GetFields.GetType.Any:
                            list = team.GetPlayersByPosition(requestBodyObject.Position);
                            break;
                        case GetFields.GetType.Fixed:
                            list = team.GetFixedPlayersByPosition(requestBodyObject.Position);
                            break;
                        case GetFields.GetType.Substitutes:
                            list = team.GetSubstitutesPlayers();
                            break;
                    }
                    context.Response.StatusCode = 200;
                    var responseJson = JsonConvert.SerializeObject(list);
                    await context.Response.WriteAsync(responseJson);
                }
            }          
        }
    }
}
