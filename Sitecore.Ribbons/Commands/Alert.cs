using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.Ribbons.Commands
{
  public class Alert : Command
  {
    public override void Execute(CommandContext context)
    {
      Assert.ArgumentNotNull(context, nameof(context));
      Context.ClientPage.Start(this, "Run");
    }

    protected void Run(ClientPipelineArgs args)
    {      
      SheerResponse.Alert("Alert command has been triggered", true);
      args.WaitForPostBack(false);
    }
  }
}