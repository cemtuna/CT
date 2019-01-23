using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT.Sfa.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("ct-button")]
    public class CTButton:TagHelper
    {
        private const string ClaimNameUser = "claim-name-user";
        [HtmlAttributeName(ClaimNameUser)]
        public string ClaimValueUser { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder stringBilder = new StringBuilder();


            
            if (context.AllAttributes.ContainsName(ClaimNameUser))
            {
                //check claim
                
            }

            stringBilder.AppendFormat("<button>Claim Test</button>");

            output.TagName = "div";
            output.Content.SetHtmlContent(stringBilder.ToString());
            
            return base.ProcessAsync(context, output);
        }

    }
}
