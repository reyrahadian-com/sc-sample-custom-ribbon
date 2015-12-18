using System;
using System.Text;
using System.Web.UI;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.ContentManager.Galleries;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.Ribbons.Gallery
{
  public class GalleryDemo : GalleryForm
  {
    protected Scrollbox Scrollbox;

    /// <summary>
    /// Raises the load event.
    /// 
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method notifies the server control that it should perform actions common to each HTTP
    ///             request for the page it is associated with, such as setting up a database query. At this
    ///             stage in the page lifecycle, server controls in the hierarchy are created and initialized,
    ///             view state is restored, and form controls reflect client-side data. Use the IsPostBack
    ///             property to determine whether the page is being loaded in response to a client postback,
    ///             or if it is being loaded and accessed for the first time.
    /// 
    /// </remarks>
    protected override void OnLoad(EventArgs eventArgs)
    {
      Assert.ArgumentNotNull(eventArgs, nameof(eventArgs));
      base.OnLoad(eventArgs);
      if (Context.ClientPage.IsEvent)
        return;

      RenderItems();
    }

    private void RenderItems()
    {
      var items = new StringBuilder();
      for (var i = 0; i < 3; i++)
      {
        items.AppendLine(string.Format("<div>Item {0}</div>", i));
      }

      Scrollbox.Controls.Add(new LiteralControl(items.ToString()));
    }

    public override void HandleMessage(Message message)
    {
      Assert.ArgumentNotNull(message, nameof(message));
      Invoke(message, true);
      message.CancelBubble = true;
      message.CancelDispatch = true;
    }
  }
}