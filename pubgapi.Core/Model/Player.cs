using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Furion.DatabaseAccessor;

namespace pubgapi.Core.Model
{
    public class Player : Entity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Player()
        {
            CreatedTime = DateTime.Now;
        }

        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(32)]
        public string PubgName { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string PubgId { get; set; }
    }
}