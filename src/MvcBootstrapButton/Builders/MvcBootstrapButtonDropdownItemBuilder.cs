using System;
using MvcBootstrapButton.Config;

namespace MvcBootstrapButton.Builders
{
    public class MvcBootstrapButtonDropdownItemBuilder
    {
        private readonly DropdownItemConfig _config;

        internal MvcBootstrapButtonDropdownItemBuilder(DropdownItemConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Sets the text for the dropdown item.
        /// </summary>
        /// <param name="text">Item text</param>
        /// <returns>The dropdown item builder instance.</returns>
        public MvcBootstrapButtonDropdownItemBuilder Text(string text)
        {
            this.CheckNullPar(text, () => nameof(text));
            _config.Text = text;
            return(this);
        }

        /// <summary>
        /// Sets the url for the dropdown item, making it perform navigation.
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>The dropdown item builder instance.</returns>
        public MvcBootstrapButtonDropdownItemBuilder Navigate(string url)
        {
            if(_config.Ajax != null)
            {
                throw(new InvalidOperationException("Not applicable when button is AJAX"));
            }
            this.CheckNullPar(url, () => nameof(url));
            _config.Url = url;
            return(this);
        }

        /// <summary>
        /// Sets the name of the javascript method to call when the item is selected.
        /// </summary>
        /// <param name="handler">Javascript method</param>
        /// <returns>The dropdown item builder instance.</returns>
        public MvcBootstrapButtonDropdownItemBuilder ClickHandler(string handler)
        {
            this.CheckNullPar(handler, () => nameof(handler));
            _config.JsHandler = handler;
            return(this);
        }

        /// <summary>
        /// Configures the drop down items AJAX behavior.
        /// </summary>
        /// <param name="configAction">Configuration action</param>
        /// <returns>The dropdown item builder instance.</returns>
        public MvcBootstrapButtonDropdownItemBuilder Ajax(Action<MvcBootstrapButtonAjaxBuilder> configAction)
        {
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
        /// Inserts a separator before the dropdown item.
        /// </summary>
        /// <returns>The dropdown item builder instance.</returns>
        public MvcBootstrapButtonDropdownItemBuilder Separated()
        {
            _config.Separated = true;
            return(this);
        }

        private void CheckNullPar(object parameter, Func<string> paramterNameFunc)
        {
            if(parameter == null)
            {
                throw(new ArgumentNullException(paramterNameFunc()));
            }
        }
    }
}