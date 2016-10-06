using System;
using Microsoft.AspNetCore.Html;
using MvcBootstrapButton.Config;
using MvcBootstrapButton.Rendering;

namespace MvcBootstrapButton.Builders
{
    public class MvcBootstrapButtonToolbarBuilder
    {
        private readonly ToolbarRenderer _renderer;
        private readonly ToolbarConfig _config;

        internal MvcBootstrapButtonToolbarBuilder(ToolbarRenderer renderer)
        {
            _renderer = renderer;
            _config = new ToolbarConfig();
        }

        /// <summary>
        /// Configures a group in the toolbar.
        /// </summary>
        /// <param name="configAction">Configuration action</param>
        /// <returns>The toolbar builder instance.</returns>
        public MvcBootstrapButtonToolbarBuilder Group(Action<MvcBootstrapButtonGroupBuilder> configAction)
        {
            GroupConfig group = new GroupConfig();
            MvcBootstrapButtonGroupBuilder builder = new MvcBootstrapButtonGroupBuilder(new GroupRenderer(), group);
            
            this.CheckNullPar(configAction, () => nameof(configAction));
            configAction(builder);
            _config.Groups.Add(group);

            return(this);
        }

        /// <summary>
        /// Sets the size for all buttons in the toolbar.
        /// </summary>
        /// <param name="size">Size</param>
        /// <param name="condition">If true, the size will be applied.</param>
        /// <returns>The toolbar builder instance.</returns>
        public MvcBootstrapButtonToolbarBuilder ButtonSize(MvcBootstrapButtonSize size, bool condition = true)
        {
            _config.ButtonSize = condition ? size : MvcBootstrapButtonSize.Default;
            return(this);
        }

        /// <summary>
        /// Sets the <see cref="ContextualState"/> for the buttons in the toolbar.
        /// </summary>
        /// <param name="state">Contextual state</param>
        /// <param name="condition">If true, the contextual state will be applied.</param>
        /// <returns>The toolbar builder instance.</returns>
        public MvcBootstrapButtonToolbarBuilder Contextual(ContextualState state, bool condition = true)
        {
            _config.State = condition ? state : ContextualState.Default;
            return(this);
        }

        /// <summary>
        /// Renders the toolbar.
        /// </summary>
        /// <returns>Html markup.</returns>
        public IHtmlContent Render()
        {
            return(_renderer.Render(_config));
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