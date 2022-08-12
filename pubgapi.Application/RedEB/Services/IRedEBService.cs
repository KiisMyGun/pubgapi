using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Furion.UnifyResult;

using pubgapi.Application.RedEB.Dtos;
using pubgapi.Application.RedEB.Reqs;

namespace pubgapi.Application.RedEB.Services
{
    /// <summary>
    /// 红包局服务
    /// </summary>
    public interface IRedEBService
    {
        Task<bool> SetPlayer(SetPlayerReq req);

        Task<RESTfulResult<LastMatchDto>> GetLastMatch(GetLastMatchReq req);
    }
}