using System.Collections.Generic;

namespace MvcBootstrapButton.Config
{
    internal class ToolbarConfig
    {
        public ToolbarConfig()
        {
            Groups = new List<GroupConfig>();
            ButtonSize = MvcBootstrapButtonSize.Default;
            State = ContextualState.Default;
        }

        public IList<GroupConfig> Groups { get; set; }
        public MvcBootstrapButtonSize ButtonSize { get; set; }
        public ContextualState State { get; set; }
    }
}
