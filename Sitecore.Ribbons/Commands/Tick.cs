using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;

namespace Sitecore.Ribbons.Commands
{
  public class Tick : Command
  {
    public override void Execute(CommandContext context)
    {
    }

    public override string GetClick(CommandContext context, string click)
    {
      //toggle the checkbox control based on a cookie value
      var script = "javascript:(function(){" +
                      "var cookie = scForm.getCookie(\"scCheckboxState\");" +
                      "if(cookie != \"0\"){" +
                        "scForm.setCookie(\"scCheckboxState\",\"0\");" +
                      "}else{" +
                        "scForm.setCookie(\"scCheckboxState\",\"1\");" +
                      "}" +
                      "var button  = scForm.browser.getControl(\"SmallCheckButton\");" +
                      "if(button){" +
                        "var ticked = scForm.getCookie(\"scCheckboxState\") != \"0\";" +
                        "button.childNodes[0].checked = ticked;" +
                        "if(ticked){" +
                          "alert(\"Checkbox was ticked\");" +
                        "}else{" +
                          "alert(\"Checkbox was unticked\");" +
                        "}" +
                      "}" +
                    "})()";
      
      return script;
    }

    public override CommandState QueryState(CommandContext context)
    {
      return CheckboxState ? CommandState.Down : CommandState.Enabled;
    }

    private static bool CheckboxState
    {
      get
      {
        return WebUtil.GetCookieValue("scCheckboxState") != "0";
      }
      set
      {
        WebUtil.SetCookieValue("scCheckboxState", value ? "1" : "0");
      }
    }
  }
}