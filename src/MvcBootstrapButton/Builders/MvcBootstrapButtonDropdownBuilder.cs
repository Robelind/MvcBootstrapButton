using System;
using MvcBootstrapButton.Config;

namespace MvcBootstrapButton.Builders
{
    public class MvcBootstrapButtonDropdownBuilder
    {
        private readonly DropdownConfig _config;

        internal MvcBootstrapButtonDropdownBuilder(DropdownConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Configures an item in the dropdown.
        /// </summary>
        /// <param name="configAction">Configuration action</param>
        /// <returns>The dropdown builder instance.</returns>
        public MvcBootstrapButtonDropdownBuilder Item(Action<MvcBootstrapButtonDropdownItemBuilder> configAction)
        {
            DropdownItemConfig itemConfig = new DropdownItemConfig();
            MvcBootstrapButtonDropdownItemBuilder builder = new MvcBootstrapButtonDropdownItemBuilder(itemConfig);
            
            this.CheckNullPar(configAction, () => nameof(configAction));
            configAction(builder);
            _config.Items.Add(itemConfig);

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