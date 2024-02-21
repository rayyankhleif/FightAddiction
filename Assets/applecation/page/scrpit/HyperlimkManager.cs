using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperlinkManager : MonoBehaviour
{
    public string Hyperlink = null;
    public void OnButtonClicked()
    {
        InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions();
        options.displayURLAsPageTitle = false;
        options.hidesHistoryButtons = true;
        options.pageTitle = "StuckE Project Browser";
        options.backButtonText = "Exit";
        options.textColor = "#ff8578";

        InAppBrowser.OpenURL(Hyperlink, options);

    }

    public void OnClearCacheClicked()
    {

        InAppBrowser.ClearCache();

    }
}
