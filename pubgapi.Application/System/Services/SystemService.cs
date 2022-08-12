using Pubg.Net;

namespace pubgapi.Application;

public class SystemService : ISystemService, ITransient
{
    public string GetDescription()
    {
        
        var apiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI5MWE2ODVjMC1mYjVlLTAxM2EtMjE1MS0yNzQ4YzRhN2Q1ZDYiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjYwMTkzMjIzLCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InJlZF9lbnZlbG9wZV9iIn0.KfO2shtP71NsQ98XkOOVl_lZFLparEXgrVArn9ysQTE";
        var playerService = new PubgPlayerService(apiKey);
        var request = new GetPubgPlayersRequest(){
             PlayerNames = new string[]{"imxiaoxin"}
        };
        var a = playerService.GetPlayers(PubgPlatform.Steam,request);

        var first = a.First().MatchIds.First();

        var matchService = new PubgMatchService();
        var b = matchService.GetMatch(first);
        return "让 .NET 开发更简单，更通用，更流行。";
    }
}
