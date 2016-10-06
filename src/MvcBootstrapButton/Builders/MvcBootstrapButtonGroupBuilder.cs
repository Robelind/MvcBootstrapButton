using System;
using Microsoft.AspNetCore.Html;
using MvcBootstrapButton.Config;
using MvcBootstrapButton.Rendering;

namespace MvcBootstrapButton.Builders
{
    public class MvcBootstrapButtonGroupBuilder
    {
        private readonly GroupRenderer _renderer;
        private readonly GroupConfig _config;

        internal MvcBootstrapButtonGroupBuilder(GroupRenderer renderer, GroupConfig config = null)
        {
            _renderer = renderer;
            _config = config ?? new GroupConfig();
        }

        /// <summary>
        /// Configures a button in the group.
        /// </summary>
        /// <param name="configAction">Configuration action</param>
        /// <returns>The group builder instance.</returns>
        public MvcBootstrapButtonGroupBuilder Button(Action<MvcBootstrapButtonBuilder> configAction)
        {
            ButtonConfig button = new ButtonConfig();
            MvcBootstrapButtonBuilder builder = new MvcBootstrapButtonBuilder(new ButtonRenderer(), button);
            
            this.CheckNullPar(configAction, () => nameof(configAction));
            configAction(builder);
            _config.Buttons.Add(button);

            return(this);
        }

        /// <summary>
        /// Sets the size for all buttons in the button group.
        /// </summary>
        /// <param name="size">Size</param>
        /// <param name="condition">If true, the size will be applied.</param>
        /// <returns>The group builder instance.</returns>
        public MvcBootstrapButtonGroupBuilder ButtonSize(MvcBootstrapButtonSize size, bool condition = true)
        {
            _config.ButtonSize = condition ? size : MvcBootstrapButtonSize.Default;
            return(this);
        }

        /// <summary>
        /// Sets the <see cref="ContextualState"/> for the buttons in the group.
        /// </summary>
        /// <param name="state">Contextual state</param>
        /// <param name="condition">If true, the contextual state will be applied.</param>
        /// <returns>The group builder instance.</returns>
        public MvcBootstrapButtonGroupBuilder Contextual(ContextualState state, bool condition = true)
        {
            _config.State = condition ? state : ContextualState.Default;
            return(this);
        }

        /// <summary>
        /// Renders the button group vertically instead of horizontally.
        /// </summary>
        /// <returns>The group builder instance.</returns>
        public MvcBootstrapButtonGroupBuilder Vertical()
        {
            _config.Vertical = true;
            return(this);
        }

        /// <summary>
        /// Renders a toolbar.
        /// </summary>
        /// <returns>The toolbar builder instance.</returns>
        public MvcBootstrapButtonToolbarBuilder Toolbar()
        {
            return(new MvcBootstrapButtonToolbarBuilder(new ToolbarRenderer()));
        }

        /// <summary>
        /// Renders the button group.
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