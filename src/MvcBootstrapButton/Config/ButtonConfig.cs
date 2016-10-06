using System;
using System.Collections.Generic;

namespace MvcBootstrapButton.Config
{
    internal class ButtonConfig
    {
        public ButtonConfig()
        {
            Id = Guid.NewGuid().ToString();
            CssClasses = new List<string>();
            State = ContextualState.Default;
            Size = MvcBootstrapButtonSize.Default;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public ContextualState State { get; set; }
        public MvcBootstrapButtonSize Size { get; set; }
        public bool Block { get; set; }
        public bool Active { get; set; }
        public bool Disabled { get; set; }
        public bool Submit { get; set; }
        public string Click { get; set; }
        public string Url { get; set; }
        public IList<string> CssClasses { get; private set; }
        public AjaxConfig Ajax { get; set; }
        public DropdownConfig Dropdown { get; set; }
    }
}
