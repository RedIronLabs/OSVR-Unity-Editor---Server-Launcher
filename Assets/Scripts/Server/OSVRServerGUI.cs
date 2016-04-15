using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles UI interaction for launching the server
/// @kerm_ed | Red Iron Labs Ltd.
/// </summary>
public class OSVRServerGUI : MonoBehaviour
{
    public Canvas RootCanvas;
    public InputField PathText;
    public InputField ExecutableText;
    public InputField ArgumentsText;
    public Toggle UsingWindowsToggle;
    public Button SaveButton;
    public Button SaveLaunchButton;
    public Button CloseButton;

    /// <summary>
    /// Started, time to load data
    /// </summary>
    private void Start()
    {
        Load();
    }

    /// <summary>
    /// User hit save
    /// </summary>
    public void SavePressed()
    {
        Save();
    }

    /// <summary>
    /// User hit save & launch
    /// </summary>
    public void SaveLaunchPressed()
    {
        Save();
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
    /// Actual logic for loading
    /// </summary>
    public void Load()
    {
        OSVRServerPaths.Load();
        PostLoadUpdate();
    }

    /// <summary>
    /// Actual logic for saving
    /// </summary>
    public void Save()
    {
        PreSavePost();
        OSVRServerPaths.CheckPath();
        OSVRServerPaths.Save();
        // Executed in case the paths changed in the CheckPath method
        PostLoadUpdate();
    }

    /// <summary>
    /// Launches the application
    /// </summary>
    public void Launch()
    {
        OSVRServerPaths.Launch();
    }

    /// <summary>
    /// Any special activites we need to do prior to saving (setting distant values)
    /// </summary>
    void PreSavePost()
    {
        OSVRServerPaths.Arguments = ArgumentsText.text;
        OSVRServerPaths.Executable = ExecutableText.text;
        OSVRServerPaths.Path = PathText.text;
        OSVRServerPaths.UsingWindows = UsingWindowsToggle.isOn;
    }

    /// <summary>
    /// Any special activities we need to do after loading (pulling distant values)
    /// </summary>
    void PostLoadUpdate()
    {
        ArgumentsText.text = OSVRServerPaths.Arguments;
        ExecutableText.text = OSVRServerPaths.Executable;
        PathText.text = OSVRServerPaths.Path;
        UsingWindowsToggle.isOn = OSVRServerPaths.UsingWindows;
    }
}
