using System;
using MvcBootstrapButton.Config;

namespace MvcBootstrapButton.Builders
{
    public class MvcBootstrapButtonAjaxBuilder
    {
        private readonly AjaxConfig _config;

        internal MvcBootstrapButtonAjaxBuilder(AjaxConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Sets the target url for the AJAX operation.
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>The AJAX builder instance.</returns>
        public MvcBootstrapButtonAjaxBuilder Url(string url)
        {
            this.CheckNullPar(url, () => nameof(url));
            _config.Url = url;
            return(this);
        }

        /// <summary>
        /// Id of the element to update with the result of
        /// the AJAX operation, when using AJAX for
        /// retrieving html.
        /// </summary>
        /// <param name="id">Element id</param>
        /// <returns>The AJAX builder instance.</returns>
        public MvcBootstrapButtonAjaxBuilder UpdateId(string id)
        {
            this.CheckNullPar(id, () => nameof(id));
            _config.UpdateId = id;
            return(this);
        }

        /// <summary>
        /// Id of an element to show when the AJAX operation
        /// is initiated and hide when it is finished.
        /// </summary>
        /// <param name="id">Element id</param>
        /// <returns>The AJAX builder instance.</returns>
        public MvcBootstrapButtonAjaxBuilder BusyIndicatorId(string id)
        {
            this.CheckNullPar(id, () => nameof(id));
            _config.BusyIndicatorId = id;
            return(this);
        }

        /// <summary>
        /// Sets the target update mode when using AJAX for
        /// retrieving html.
        /// Default mode is 'Replace';
        /// </summary>
        /// <param name="mode">Update mode</param>
        /// <returns>The AJAX builder instance.</returns>
        public MvcBootstrapButtonAjaxBuilder UpdateMode(AjaxUpdateMode mode)
        {
            _config.UpdateMode = mode;
            return(this);
        }

        /// <summary>
        /// Name of java script function to call when
        /// the AJAX operation is initiated.
        /// </summary>
        /// <param name="func">Javascript function</param>
        /// <returns>The AJAX builder instance.</returns>
        public MvcBootstrapButtonAjaxBuilder Start(string func)
        {
            _config.Start = func;
            return(this);
        }

        /// <summary>
        /// Name of java script function to call when
        /// the AJAX operation is successful.
        /// The function will recieve the data received from
        /// the AJAX call as a parameter.
        /// </summary>
        /// <param name="func">Javascript function</param>
        /// <returns>The AJAX builder instance.</returns>
        public MvcBootstrapButtonAjaxBuilder Success(string func)
        {
            _config.Success = func;
            return(this);
        }

        /// <summary>
        /// Name of java script function to call when
        /// the AJAX operation fails.
        /// </summary>
        /// <param name="func">Javascript function</param>
        /// <returns>The AJAX builder instance.</returns>
        public MvcBootstrapButtonAjaxBuilder Error(string func)
        {
            _config.Error = func;
            return(this);
        }

        /// <summary>
        /// Name of java script function to call when
        /// the AJAX operation is complete.
        /// </summary>
        /// <param name="func">Javascript function</param>
        /// <returns>The AJAX builder instance.</returns>
        public MvcBootstrapButtonAjaxBuilder Complete(string func)
        {
            _config.Complete = func;
            return(this);
        }

        /// <summary>
        /// Disables the button when the AJAX operation is initiated
        /// and enables it when it is finished.
        /// </summary>
        /// <returns>The AJAX builder instance.</returns>
        public MvcBootstrapButtonAjaxBuilder ButtonState()
        {
            _config.ButtonState = true;
            return(this);
        }

        /// <summary>
        /// Wheather tho clear the update area when the AJAX operation
        /// is initiated.
        /// </summary>
        /// <returns>The AJAX builder instance.</returns>
        public MvcBootstrapButtonAjaxBuilder ClearUpdateArea(bool condition = true)
        {
            _config.ClearUpdateArea = condition;
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