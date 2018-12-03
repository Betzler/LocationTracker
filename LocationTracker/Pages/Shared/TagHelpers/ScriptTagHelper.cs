using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LocationTracker.TagHelpers
{
    [HtmlTargetElement("script", Attributes = "on-content-loaded")]
    public class ScriptTagHelper : TagHelper
    {
        public bool OnContentLoaded { get; set; } = false;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(!OnContentLoaded)
            {
                base.Process(context, output);
            }
            else
            {
                var content = output.GetChildContentAsync().Result;
                var javascript = content.GetContent();

                var stringBuilder = new StringBuilder();
                stringBuilder.Append("document.addEventListener('DOMContentLoaded',");
                stringBuilder.Append("function () {");
                stringBuilder.Append(javascript);
                stringBuilder.Append("});");

                output.Content.SetHtmlContent(stringBuilder.ToString());
            }

        }
    }
}
