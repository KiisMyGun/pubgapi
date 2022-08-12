using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Furion.UnifyResult;

using pubgapi.Application.RedEB.Dtos;
using pubgapi.Application.RedEB.Reqs;
using pubgapi.Application.RedEB.Services;

namespace pubgapi.Application.System
{
    /// <summary>
    /// 红包局控制器
    /// </summary>
    public class RedEBAppService : IDynamicApiController
    {
        private readonly IRedEBService _redEBService;

        public RedEBAppService(IRedEBService redEBService)
        {
            _redEBService = redEBService;
        }

        /// <summary>
        /// 设置玩家
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> SetPlayer(SetPlayerReq req) => await _redEBService.SetPlayer(req);

        /// <summary>
        /// 获取最后一场对局
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<RESTfulResult<LastMatchDto>> GetLastMatch(GetLastMatchReq req) => await _redEBService.GetLastMatch(req);
    }
}