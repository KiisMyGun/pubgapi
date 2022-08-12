using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubgapi.Application.RedEB.Dtos
{
    /// <summary>
    /// 最后一次对局
    /// </summary>
    public class LastMatchDto
    {
        public bool Won { get; set; }
        public IEnumerable<TeamPlay> TeamPlays { get; set; }

        public class TeamPlay
        {
            /// <summary>
            /// 玩家昵称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 击杀人数
            /// </summary>
            public int Kills { get; set; }
        }
    }
}