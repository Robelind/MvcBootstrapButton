using System;
using Microsoft.AspNetCore.Html;
using MvcBootstrapButton.Config;
using MvcBootstrapButton.Rendering;

namespace MvcBootstrapButton.Builders
{
    public class MvcBootstrapButtonBuilder
    {
        private readonly IButtonRenderer _renderer;
        private readonly Config.ButtonConfig _config;

        internal MvcBootstrapButtonBuilder(IButtonRenderer renderer, Config.ButtonConfig config = null)
        {
            _renderer = renderer;
            _config = config ?? new Config.ButtonConfig();
        }

        /// <summary>
        /// Sets the id attribute for the table.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Id(string id)
        {
            _config.Id = id;
            return(this);
        }

        /// <summary>
        /// Sets the name attribute for the table.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Name(string name)
        {
            _config.Name = name;
            return(this);
        }

        /// <summary>
        /// Sets the button text.
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Text(string text)
        {
            _config.Text = text;
            return(this);
        }

        /// <summary>
        /// Sets the <see cref="ContextualState"/> of the button.
        /// </summary>
        /// <param name="state">Contextual state</param>
        /// <param name="condition">If true, the contextual state will be applied.</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Contextual(ContextualState state, bool condition = true)
        {
            _config.State = condition ? state : ContextualState.Default;
            return(this);
        }

        /// <summary>
        /// Sets the button size.
        /// </summary>
        /// <param name="size">Size</param>
        /// <param name="condition">If true, the size will be applied.</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Size(MvcBootstrapButtonSize size, bool condition = true)
        {
            _config.Size = condition ? size : MvcBootstrapButtonSize.Default;
            return(this);
        }

        /// <summary>
        /// Sets the button to block level.
        /// </summary>
        /// <param name="condition">If true, the button will be block level.</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Block(bool condition = true)
        {
            _config.Block = condition;
            return(this);
        }

        /// <summary>
        /// Sets the button to active.
        /// </summary>
        /// <param name="condition">If true, the button will be set to active.</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Active(bool condition = true)
        {
            _config.Active = condition;
            return(this);
        }

        /// <summary>
        /// Sets the button to disabled.
        /// </summary>
        /// <param name="condition">If true, the button will be set to disabled.</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Disabled(bool condition = true)
        {
            _config.Disabled = condition;
            return(this);
        }

        /// <summary>
        /// Renders a submit button.
        /// </summary>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Submit()
        {
            if(_config.Url != null)
            {
                throw(new InvalidOperationException("Not applicable when button is navigational"));
            }
            if(_config.Ajax != null)
            {
                throw(new InvalidOperationException("Not applicable when button is AJAX"));
            }
            _config.Submit = true;
            return(this);
        }

        /// <summary>
        /// Configures a java script function to be called the button is clicked.
        /// </summary>
        /// <param name="jsFunc">Name of java script function.</param>
        /// <param name="condition">If true, the java script function will be called.</param>
        /// <returns>The button builder instance.</returns>
        /// <remarks>The java script function will receive the buttons id as a parameter.</remarks>
        public MvcBootstrapButtonBuilder Click(string jsFunc, bool condition = true)
        {
            if(condition)
            {
                _config.Click = jsFunc;
            }
            return(this);
        }

        /// <summary>
        /// Renders the button for navigation.
        /// </summary>
        /// <param name="url">Url to navigate to.</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Navigate(string url)
        {
            if(_config.Submit)
            {
                throw(new InvalidOperationException("Not applicable when button is submit"));
            }
            if(_config.Ajax != null)
            {
                throw(new InvalidOperationException("Not applicable when button is AJAX"));
            }
            if(url == null)
            {
                throw(new ArgumentNullException(nameof(url)));
            }
            _config.Url = url;
            return(this);
        }

        /// <summary>
        /// Sets a css class for the table element.
        /// </summary>
        /// <param name="cssClass">Name of css class.</param>
        /// <param name="condition">If true, the css class will be set for the button element.</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder CssClass(string cssClass, bool condition = true)
        {
            if(condition)
            {
                _config.CssClasses.Add(cssClass);
            }
            return(this);
        }

        /// <summary>
        /// Configures the buttons AJAX behavior.
        /// </summary>
        /// <param name="configAction">Configuration action</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Ajax(Action<MvcBootstrapButtonAjaxBuilder> configAction)
        {
            if(_config.Submit)
            {
                throw(new InvalidOperationException("Not applicable when button is submit"));
            }
            if(_config.Url != null)
            {
                throw(new InvalidOperationException("Not applicable when button is navigational"));
            }
            if(configAction == null)
            {
                throw(new ArgumentNullException(nameof(configAction)));
            }
            _config.Ajax = new AjaxConfig();
            configAction(new MvcBootstrapButtonAjaxBuilder(_config.Ajax));

            return(this);
        }

        /// <summary>
        /// Configures the buttons AJAX behavior.
        /// </summary>
        /// <param name="configAction">Configuration action</param>
        /// <returns>The button builder instance.</returns>
        public MvcBootstrapButtonBuilder Dropdown(Action<MvcBootstrapButtonDropdownBuilder> configAction)
        {
            if(_config.Submit)
            {
                throw(new InvalidOperationException("Not applicable when button is submit"));
            }
            /*if(_config.Url != null)
            {
                throw(new InvalidOperationException("Not applicable when button is link"));
            }
            if(_config.Ajax != null)
            {
                throw(new InvalidOperationException("Not applicable when button has AJAX functionality"));
            }*/
            if(configAction == null)
            {
                throw(new ArgumentNullException(nameof(configAction)));
            }
            _config.Dropdown = new DropdownConfig();
            configAction(new MvcBootstrapButtonDropdownBuilder(_config.Dropdown));

            return(this);
        }

        /// <summary>
        /// Renders the button.
        /// </summary>
        /// <returns></returns>
        public IHtmlContent Render()
        {
            return(_renderer.Render(_config));
        }
    }
}