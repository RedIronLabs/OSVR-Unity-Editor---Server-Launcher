using UnityEngine;
using UnityEditor;

/// <summary>
/// Sets an Editor GUI window for setting up execution
/// NOTE:  Place this in /Scripts/Editor
/// </summary>
public class OSVRWindowPaths : EditorWindow
{

    /// <summary>
    /// User launched the window
    /// </summary>
    [MenuItem("Window/OSVR Server")]
    public static void ShowWindow()
    {
        OSVRServerPaths.Load();
        GetWindow(typeof(OSVRWindowPaths));
    }

    /// <summary>
    /// Drawing of the frame
    /// </summary>
    void OnGUI()
    {
        GUILayout.Label("Settings", EditorStyles.boldLabel);

        OSVRServerPaths.UsingWindows = EditorGUILayout.ToggleLeft("Using Windows?", OSVRServerPaths.UsingWindows);

        OSVRServerPaths.Path = EditorGUILayout.TextField("Path", OSVRServerPaths.Path);
        EditorGUILayout.TextArea("    Example:  C:\\dev\\osvr-latest\\");

        OSVRServerPaths.Executable = EditorGUILayout.TextField("Executable", OSVRServerPaths.Executable);
        EditorGUILayout.TextArea("    Example:  osvr_server.exe");

        OSVRServerPaths.Arguments = EditorGUILayout.TextField("Arguments", OSVRServerPaths.Arguments);
        EditorGUILayout.TextArea("    Example:  osvr_server_config-oculusrift.json");

        if (GUILayout.Button("Save & Launch"))
        {
            OSVRServerPaths.CheckPath();
            OSVRServerPaths.Save();
            OSVRServerPaths.Launch();
        }
        if (GUILayout.Button("Save"))
        {
            OSVRServerPaths.CheckPath();
            OSVRServerPaths.Save();
        }
        if (GUILayout.Button("Close"))
        {
            Quit();
        }
    }
    
    /// <summary>
    /// User has exited the window
    /// </summary>
    void Quit()
    {
        Close();
    }


}
