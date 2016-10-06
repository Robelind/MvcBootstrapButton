using Microsoft.AspNetCore.Mvc.Rendering;
using MvcBootstrapButton.Builders;
using MvcBootstrapButton.Rendering;

namespace MvcBootstrapButton
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Renders an Mvc Bootstrap button.
        /// </summary>
        /// <param name="htmlHelper">Html helper instance.</param>
        /// <returns>Button builder.</returns>
        public static MvcBootstrapButtonBuilder MvcBootstrapButton(this IHtmlHelper htmlHelper)
        {
            return(new MvcBootstrapButtonBuilder(new ButtonRenderer()));
        }

        /// <summary>
        /// Renders an Mvc Bootstrap button group.
        /// </summary>
        /// <param name="htmlHelper">Html helper instance.</param>
        /// <returns>Button group builder.</returns>
        public static MvcBootstrapButtonGroupBuilder MvcBootstrapButtonGroup(this IHtmlHelper htmlHelper)
        {
            return(new MvcBootstrapButtonGroupBuilder(new GroupRenderer()));
        }
    }
}
