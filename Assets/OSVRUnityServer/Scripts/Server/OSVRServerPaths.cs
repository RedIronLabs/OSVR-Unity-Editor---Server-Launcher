using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

/// <summary>
/// Set the paths tot he OSVR Server
/// NOTE:  Place this in /Scripts
/// </summary>
public static class OSVRServerPaths  {

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
        if (ProcessActive())
        {
            UnityEngine.Debug.LogWarning("[OSVR-Unity] Server instance found, cannot launch server.  Either set OSVRServerPaths._cycleProcess to true, or manually close the OSVR Server instance");
            return;
        }

        Process.Start(new ProcessStartInfo
        {
            WorkingDirectory = Path,
            FileName = Executable,
            Arguments = Arguments,
            ErrorDialog = true
        });
    }

    private static bool _cycleProcess = false;
    private static string _processName = "osvr_server";

    /// <summary>
    /// Checks if a process is active, if the bool _cycleProcess is true, it will kill any active processes - allows for automatic cycling of server instances
    /// </summary>
    /// <returns></returns>
    public static bool ProcessActive()
    {
        if (!_cycleProcess)
            return Process.GetProcesses().Any(x => x.ProcessName == _processName);
        else
        {
            var processes = Process.GetProcesses().Where(x => x.ProcessName == _processName);
            foreach (var process in processes)
            {
                UnityEngine.Debug.LogWarning("[OSVR-Unity] Server instance found, stopping " + process.ProcessName);
                process.Kill();
            }
            return false;
        }
    }

    /// <summary>
    /// Sets the path trailing character depending on the OS
    /// </summary>
    public static void CheckPath()
    {
        var trailingCharacter = UsingWindows ? "\\" : "/";
        if ((Path.Substring(Path.Length - 1, 1)) != trailingCharacter)
            Path += trailingCharacter;
    }
}
