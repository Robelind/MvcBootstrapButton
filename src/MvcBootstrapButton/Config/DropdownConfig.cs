using System.Collections.Generic;

namespace MvcBootstrapButton.Config
{
    internal class DropdownConfig
    {
        public DropdownConfig()
        {
            Items = new List<DropdownItemConfig>();
        }

        public IList<DropdownItemConfig> Items { get; set; }
    }
}
