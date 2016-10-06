namespace MvcBootstrapButton.Config
{
    internal class AjaxConfig
    {
        public AjaxConfig()
        {
            UpdateMode = AjaxUpdateMode.Replace;
        }

        public string Url { get; set; }
        public string UpdateId { get; set; }
        public string BusyIndicatorId { get; set; }
        public string Start { get; set; }
        public string Success { get; set; }
        public string Error { get; set; }
        public string Complete { get; set; }
        public bool ClearUpdateArea { get; set; }
        public bool ButtonState { get; set; }
        public AjaxUpdateMode UpdateMode { get; set; }
    }
}
