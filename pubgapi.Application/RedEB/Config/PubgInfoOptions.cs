using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Furion.ConfigurableOptions;

using Microsoft.Extensions.Configuration;

using Pubg.Net;

namespace pubgapi.Application.RedEB.Config
{
    public class PubgInfoOptions : IConfigurableOptionsListener<PubgInfoOptions>
    {
        public string ApiKey { get; set; }

        public PubgInfoOptions()
        {
        }

        public void OnListener(PubgInfoOptions options, IConfiguration configuration)
        {
            PubgApiConfiguration.SetApiKey(options.ApiKey);
        }

        public void PostConfigure(PubgInfoOptions options, IConfiguration configuration)
        {
        }
    }
}