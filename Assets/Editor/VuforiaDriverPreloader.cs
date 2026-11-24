#if UNITY_EDITOR_WIN
using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public static class VuforiaDriverPreloader
{
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern IntPtr LoadLibrary(string lpFileName);

    [InitializeOnLoadMethod]
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void PreloadVuforiaDrivers()
    {
        string pluginsDir = Path.GetFullPath("Packages/com.ptc.vuforia.engine/Vuforia/Plugins/Windows/x64");
        if (!Directory.Exists(pluginsDir))
            return;

        string unityDriverPath = Path.Combine(pluginsDir, "UnityDriver.dll");
        if (File.Exists(unityDriverPath))
            LoadLibrary(unityDriverPath);

        string fileDriverPath = Path.Combine(pluginsDir, "FileDriver.dll");
        if (File.Exists(fileDriverPath))
            LoadLibrary(fileDriverPath);
    }
}
#endif