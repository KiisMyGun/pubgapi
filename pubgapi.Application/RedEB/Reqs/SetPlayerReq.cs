using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubgapi.Application.RedEB.Reqs
{
    public class SetPlayerReq : BaseReq
    {
        [MaxLength(50, ErrorMessage = "最大输入50个字符"),
             MinLength(1, ErrorMessage = "最小输入1个字符"),
             Required(ErrorMessage = "必填玩家昵称")]
        public string playName { get; set; }
    }
}