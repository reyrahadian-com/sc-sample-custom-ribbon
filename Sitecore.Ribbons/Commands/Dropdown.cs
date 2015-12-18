using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.Ribbons.Commands
{
  public class Dropdown : Command
  {
    public override void Execute(CommandContext context)
    {
      Assert.IsNotNull(context, nameof(context));
      //get form value from the dropdown box control
      //the field name is formatted by Input_<TheControlId>
      var selectedItem = WebUtil.GetFormValue("Input_SmallDropdownBox");
      if (!string.IsNullOrWhiteSpace(selectedItem))
      {
        SheerResponse.Eval("alert(\"" + selectedItem + " was selected\")");
      }
    }
  }
}