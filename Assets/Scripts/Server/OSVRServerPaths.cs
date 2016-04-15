using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Set the paths tot he OSVR Server
/// NOTE:  Place this in /Scripts
/// @kerm_ed | Red Iron Labs Ltd.
/// </summary>
public static class OSVRServerPaths
{
    public static string Path = "\\";
    public static string Executable = "\\osvr_server.exe";
    public static string Arguments = "";
    public static bool UsingWindows = true;

    /// <summary>
    /// Loads the application server information
    /// </summary>
    public static void Load()
    {
        Path = PlayerPrefs.GetString("_path", "\\");
        Executable = PlayerPrefs.GetString("_executable", "osvr_server.exe");
        Arguments = PlayerPrefs.GetString("_args", "");
        UsingWindows = bool.Parse(PlayerPrefs.GetString("_usingWindows", "true"));
    }

    /// <summary>
    /// Saves the application server information
    /// </summary>
    public static void Save()
    {
        PlayerPrefs.SetString("_path", Path);
        PlayerPrefs.SetString("_executable", Executable);
        PlayerPrefs.SetString("_args", Arguments);
        PlayerPrefs.SetString("_usingWindows", UsingWindows.ToString());
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Launches the application
    /// </summary>
    public static void Launch()
    {
        Process.Start(new ProcessStartInfo
        {
            WorkingDirectory = Path,
            FileName = Executable,
            Arguments = Arguments,
            ErrorDialog = true
        });
    }

    /// <summary>
    /// Sets the path trailing character depending on the OS
    /// </summary>
    public static void CheckPath()
    {
        if (string.IsNullOrEmpty(Path))
            return;

        var trailingCharacter = UsingWindows ? "\\" : "/";
        if ((Path.Substring(Path.Length - 1, 1)) != trailingCharacter)
            Path += trailingCharacter;
    }
}
