using UnityEngine;

/// <summary>
/// Autolaunches the server, currently not ready in the DLL's
/// </summary>
public class OSVRServerAutolaunchGUI : MonoBehaviour {

    public Canvas RootCanvas;

    /// <summary>
    /// User hit launch
    /// </summary>
    public void LaunchPressed()
    {
        Launch();
    }

    /// <summary>
    /// User hit close
    /// </summary>
    public void ClosePressed()
    {
        ClosePanel();
    }

    /// <summary>
    /// Actual logic for closing
    /// </summary>
    private void ClosePanel()
    {
        RootCanvas.enabled = false;
    }

    /// <summary>
    /// Launches the application
    /// </summary>
    public void Launch()
    {
        // Not ready yet
        // OSVR.ClientKit.ServerAutoStart();
    }
}
