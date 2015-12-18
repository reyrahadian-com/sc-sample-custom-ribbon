using System.Collections.Generic;
using System.Web.UI;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Shell.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls.Ribbons;

namespace Sitecore.Ribbons
{
  public class Panel : RibbonPanel
  {
    public override void Render(HtmlTextWriter output, Ribbon ribbon, Item button, CommandContext context)
    {
      Assert.ArgumentNotNull(output, nameof(output));
      Assert.ArgumentNotNull(ribbon, nameof(ribbon));
      Assert.ArgumentNotNull(button, nameof(button));
      Assert.ArgumentNotNull(context, nameof(context));
      output.Write("<div id=\"CustomPanelHolder\" class=\"scRibbonGallery\">");
      output.Write("<div id=\"CustomPanelList\" class=\"scRibbonGalleryList\">");
      var items = ItemUtil.GetChildrenAt("/sitecore/content/Applications/Content Editor/Menues/Custom Menus");
      RenderItems(output, items);
      output.Write("</div>");
      RenderPanelButtons(output, "CustomPanelList", string.Empty);
      output.Write("</div>");
    }

    private void RenderItems(HtmlTextWriter output, List<Item> items)
    {
      foreach (var item in items)
      {
        output.Write("<a href=\"javascript:void(0)\" class=\"scRibbonToolbarSmallButton\" onclick=\"javascript:return scForm.postEvent(this,event,'customribbons:alert')\"><span class=\"header\">{0}</span></a>", item.DisplayName);
      }
    }
  }
}