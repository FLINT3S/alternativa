using System.Linq;
using Database;
using Database.Models;
using GTANetworkAPI;

    namespace TestResource
    {
    public class Main : Script
        {
            [Command("register")]
            public void CmdOnRegister(Player player, string nickname)
            {
                using (var dbContext = new AlternativaContext())
                {
                    var newUser = new User
                    {
                        Name = player.Name,
                        Nickname = nickname
                    };
                    
                    dbContext.Users.Add(newUser);
                    dbContext.SaveChanges();
                    NAPI.Util.ConsoleOutput("New user registered: " + newUser.Name + " with nickname: " + newUser.Nickname);
                }
            }
            
            [ServerEvent(Event.ResourceStart)]
            public void OnResourceStart()
            {
                using (var dbContext = new AlternativaContext())
                {
                    var playerCount = dbContext.Users.Count();
                    NAPI.Util.ConsoleOutput("Total players in the database: " + playerCount);
                }
            }
            
            [ServerEvent(Event.PlayerConnected)]
            public void OnPlayerConnected(Player player)
            {
                using (var dbContext = new AlternativaContext())
                {
                    var connectedUser = dbContext.Users.Where(u => u.Name == player.Name).FirstOrDefault();
                    
                    var userConnected = new UserEvent
                    {
                        Type = UserEventType.Connected,
                        User = connectedUser
                    };

                    var connectionsCount = dbContext.UserEvents.Where(ue => ue.User == connectedUser).Count();
                    NAPI.Util.ConsoleOutput("Connected: " + connectionsCount);
                    dbContext.UserEvents.Add(userConnected);
                    dbContext.SaveChanges();
                }
            }
        }
    }
    