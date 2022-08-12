using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Furion.UnifyResult;

using Pubg.Net;

using pubgapi.Application.RedEB.Dtos;
using pubgapi.Application.RedEB.Reqs;
using pubgapi.Core.Model;

using static pubgapi.Application.RedEB.Dtos.LastMatchDto;

namespace pubgapi.Application.RedEB.Services
{
    public class RedEBService : IRedEBService, ITransient
    {
        private readonly IRepository<Player> _playerRepository;

        public RedEBService(IRepository<Player> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<bool> SetPlayer(SetPlayerReq req)
        {
            try
            {
                var isHave = await _playerRepository.AnyAsync(f => f.PubgName == req.playName.Trim());
                if (isHave)
                    return true;

                // 玩家
                var playerService = new PubgPlayerService(req.pubgApiKey);
                GetPubgPlayersRequest getPubgPlayersRequest = new GetPubgPlayersRequest()
                {
                    PlayerNames = new string[] { req.playName }
                };
                var players = await playerService.GetPlayersAsync(PubgPlatform.Steam, getPubgPlayersRequest);

                var player = players.FirstOrDefault();

                _playerRepository.InsertNow(new Player() { PubgId = player.Id, PubgName = player.Name });

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message == "API returned 404. An entity with the specified ID was not found")
                    throw Oops.Oh("没有此玩家!");
                if (ex.Message == "Api Key is invalid or missing!")
                    throw Oops.Oh("Token是错的，请重新填！");
                throw Oops.Oh("FK!!! 用的人太多了，作者顶不住了，请用自己的Token.");
            }
        }

        public async Task<RESTfulResult<LastMatchDto>> GetLastMatch(GetLastMatchReq req)
        {
            try
            {
                // 玩家
                var playerService = new PubgPlayerService();
                GetPubgPlayersRequest getPubgPlayersRequest = new GetPubgPlayersRequest()
                {
                    PlayerNames = new string[] { req.playName }
                };
                var players = await playerService.GetPlayersAsync(PubgPlatform.Steam, getPubgPlayersRequest);

                var player = players.FirstOrDefault();

                var playerId = player.Id;

                var matcheId = player.MatchIds?.FirstOrDefault();

                if (!string.IsNullOrEmpty(matcheId))
                {
                    var matchService = new PubgMatchService();
                    var pubgMatch = matchService.GetMatch(matcheId);
                    var pubgRoster = pubgMatch.Rosters.Where(f => f.Participants.Any(m => m.Stats.PlayerId == playerId)).First();

                    LastMatchDto lastMatchDto = new LastMatchDto()
                    {
                        Won = pubgRoster.Won,
                        TeamPlays = pubgRoster.Participants.Select(f => new TeamPlay()
                        {
                            Name = f.Stats.Name,
                            Kills = f.Stats.Kills,
                        })
                    };
                    return new RESTfulResult<LastMatchDto>() { Data = lastMatchDto, Errors = "xixix" };
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }
    }
}