using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcBootstrapButton.Config;

namespace MvcBootstrapButton.Rendering
{
    internal interface IButtonRenderer
    {
        IHtmlContent Render(Config.ButtonConfig config);
    }

    internal class ButtonRenderer : IButtonRenderer
    {
        private Config.ButtonConfig _config;
        private TagBuilder _button;
        private TagBuilder _group;

        public IHtmlContent Render(Config.ButtonConfig config)
        {
            _config = config;
            _button = _config.Url != null || _config.Ajax != null
                ? new TagBuilder("a")
                : new TagBuilder("button");
            _button.AddCssClass("btn");
            if(_config.Url == null)
            {
                this.AddAttribute("type", _config.Submit ? "submit" : "button");
            }
            else
            {
                _button.Attributes.Add("role", "button");
            }
            this.AddAttribute("id", config.Id);
            this.AddAttribute("name", config.Name);
            this.AddAttribute("href", config.Url);
            this.AddAttribute("onclick", this.AddJavascriptFuncPars(config.Id, config.Click, false));
            if(!string.IsNullOrEmpty(config.Text))
            {
                _button.InnerHtml.Append(config.Text);
            }
            this.AddContextualState(config.State);
            this.SetSize();
            this.AddClassIf("btn-block", _config.Block);
            this.AddClassIf("active", _config.Active);
            if(_config.Disabled)
            {
                if(_config.Url == null)
                {
                    _button.Attributes.Add("disabled", "disabled");
                }
                else
                {
                    _button.AddCssClass("disabled");
                }
            }
            this.AddCssClasses(config.CssClasses);
            this.Dropdown();
            this.Ajax(_button, _config.Ajax, config.Id);
                        
            return(_group ?? _button);
        }

        private void Ajax(TagBuilder element, AjaxConfig config, string elementId = null)
        {
            if(config != null)
            {
                element.Attributes.Add("data-ajax", "true");
                element.Attributes.Add("data-ajax-update", $"#{config.UpdateId}");
                element.Attributes.Add("data-ajax-mode", config.UpdateMode.ToString().ToLower());
                element.Attributes.Add("data-ajax-url", config.Url);
                element.Attributes.Add("data-ajax-loading", "#" + config.BusyIndicatorId);
                element.Attributes.Add("data-ajax-begin", $"{this.AddJavascriptFuncPars(elementId, config.Start)}");
                element.Attributes.Add("data-ajax-success", $"{this.AddJavascriptFuncPars(elementId, config.Success, true, true)}");
                element.Attributes.Add("data-ajax-failure", $"{this.AddJavascriptFuncPars(elementId, config.Error)}");
                element.Attributes.Add("data-ajax-complete", $"{this.AddJavascriptFuncPars(elementId, config.Complete)}");
                if(config.ClearUpdateArea)
                {
                    string js = element.Attributes.ContainsKey("onclick")
                        ? element.Attributes["onclick"]
                        : null;

                    element.Attributes.Remove("onclick");
                    js += $"$('#{config.UpdateId}').html('');";
                    this.AddAttribute("onclick", js);
                }
            }
        }

        private void Dropdown()
        {
            if(_config.Dropdown != null)
            {
                TagBuilder caret = new TagBuilder("span");
                TagBuilder menu = new TagBuilder("ul");
                bool splitBtn = _config.Url != null || _config.Ajax != null;
                TagBuilder toggleBtn = null;

                if(splitBtn)
                {
                    toggleBtn = new TagBuilder("button");
                    toggleBtn.AddCssClass("dropdown-toggle");
                    toggleBtn.AddCssClass("btn");
                    toggleBtn.AddCssClass("btn-" + _config.State.ToString().ToLower());
                    toggleBtn.Attributes.Add("data-toggle", "dropdown");
                }
                else
                {
                    _button.AddCssClass("dropdown-toggle");
                    _button.Attributes.Add("data-toggle", "dropdown");
                }

                _group = new TagBuilder("div");
                _group.AddCssClass("btn-group");
                caret.AddCssClass("caret");
                _group.InnerHtml.AppendHtml(_button);
                if(toggleBtn != null)
                {
                    TagBuilder srOnly = new TagBuilder("span");

                    _group.InnerHtml.AppendHtml(toggleBtn);
                    toggleBtn.InnerHtml.AppendHtml(caret);
                    srOnly.AddCssClass("sr-only");
                    toggleBtn.InnerHtml.AppendHtml(srOnly);
                }
                else
                {
                    _button.InnerHtml.AppendHtml(caret);
                }
                _group.InnerHtml.AppendHtml(menu);

                menu.AddCssClass("dropdown-menu");
                foreach(DropdownItemConfig item in _config.Dropdown.Items)
                {
                    TagBuilder menuItem = new TagBuilder("li");
                    TagBuilder link = new TagBuilder("a");

                    if(item.Separated)
                    {
                        TagBuilder separator = new TagBuilder("li");

                        separator.AddCssClass("divider");
                        separator.Attributes.Add("role", "separator");
                        menu.InnerHtml.AppendHtml(separator);
                    }

                    link.InnerHtml.Append(item.Text);
                    menuItem.InnerHtml.AppendHtml(link);

                    this.Ajax(link, item.Ajax);
                    if(item.JsHandler != null)
                    {
                        link.Attributes.Add("onclick", item.JsHandler);
                        link.Attributes.Add("href", "javascript:void(0)");
                    }
                    else
                    {
                        link.Attributes.Add("href", item.Url);
                    }

                    menu.InnerHtml.AppendHtml(menuItem);
                }
            }
        }

        private void AddClassIf(string cssClass, bool condition)
        {
            if(condition)
            {
                _button.AddCssClass(cssClass);
            }
        }

        private void SetSize()
        {
            switch(_config.Size)
            {
                case MvcBootstrapButtonSize.Large:
                    _button.AddCssClass("btn-lg");
                    break;
                case MvcBootstrapButtonSize.Default:
                    break;
                case MvcBootstrapButtonSize.Small:
                    _button.AddCssClass("btn-sm");
                    break;
                case MvcBootstrapButtonSize.ExtraSmall:
                    _button.AddCssClass("btn-xs");
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        private void AddAttribute(string attribute, string value)
        {
            if(!string.IsNullOrEmpty(value))
            {
                _button.Attributes.Add(attribute, value);
            }
        }

        private void AddCssClasses(IEnumerable<string> cssClasses)
        {
            foreach(var cssClass in cssClasses)
            {
                _button.AddCssClass(cssClass);
            }
        }

        private void AddContextualState(ContextualState state)
        {
            _button.AddCssClass("btn-" + state.ToString().ToLower());
        }

        private string AddJavascriptFuncPars(string elementId, string jsFunc, bool forAjax = true, bool data = false)
        {
            if(jsFunc != null)
            {
                jsFunc = forAjax
                    ? data
                        ? jsFunc + $"('{_config.Id}', data);"
                        : jsFunc + $"('{_config.Id}');"
                    : jsFunc + $"('{_config.Id}');";
            }

            return(jsFunc);
        }
    }
}