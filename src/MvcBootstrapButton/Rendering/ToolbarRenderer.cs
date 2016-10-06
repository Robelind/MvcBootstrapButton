using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcBootstrapButton.Config;

namespace MvcBootstrapButton.Rendering
{
    internal class ToolbarRenderer
    {
        public IHtmlContent Render(ToolbarConfig config)
        {
            TagBuilder toolbar = new TagBuilder("div");
            GroupRenderer groupRenderer = new GroupRenderer();

            toolbar.AddCssClass("btn-toolbar");
            toolbar.Attributes.Add("role", "toolbar");
            foreach(GroupConfig group in config.Groups)
            {
                group.ButtonSize = config.ButtonSize;
                group.State = config.State;
                toolbar.InnerHtml.AppendHtml(groupRenderer.Render(group));
            }

            return(toolbar);
        }
    }
}
