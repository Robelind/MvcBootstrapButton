using System.Diagnostics;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcBootstrapButton.Config;

namespace MvcBootstrapButton.Rendering
{
    internal class GroupRenderer
    {
        public IHtmlContent Render(GroupConfig config)
        {
            TagBuilder group = new TagBuilder("div");
            ButtonRenderer buttonRenderer = new ButtonRenderer();

            group.AddCssClass(config.Vertical ? "btn-group-vertical": "btn-group");
            group.Attributes.Add("role", "group");
            this.ButtonSize(group, config);
            foreach(ButtonConfig button in config.Buttons)
            {
                if(button.Dropdown != null)
                {
                    button.Size = config.ButtonSize;
                }
                button.State = config.State;
                group.InnerHtml.AppendHtml(buttonRenderer.Render(button));
            }

            return(group);
        }

        private void ButtonSize(TagBuilder group, GroupConfig config)
        {
            switch(config.ButtonSize)
            {
                case MvcBootstrapButtonSize.Large:
                    group.AddCssClass("btn-group-lg");
                    break;
                case MvcBootstrapButtonSize.Default:
                    break;
                case MvcBootstrapButtonSize.Small:
                    group.AddCssClass("btn-group-sm");
                    break;
                case MvcBootstrapButtonSize.ExtraSmall:
                    group.AddCssClass("btn-group-xs");
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }
    }
}

