﻿using System.Collections.Generic;

namespace MvcBootstrapButton.Config
{
    internal class GroupConfig
    {
        public GroupConfig()
        {
            Buttons = new List<ButtonConfig>();
            Groups = new List<GroupConfig>();
            ButtonSize = MvcBootstrapButtonSize.Default;
            State = ContextualState.Default;
        }

        public IList<ButtonConfig> Buttons { get; set; }
        public IList<GroupConfig> Groups { get; set; }
        public bool Vertical { get; set; }
        public MvcBootstrapButtonSize ButtonSize { get; set; }
        public ContextualState State { get; set; }
    }
}
