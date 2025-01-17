using UnityEditor;
using UnityEngine;

public class UpdateGameSpeed : Editor
{
    [MenuItem("Tools/Game Speed/Time speed 3x")]
    public static void UpdateTimeSpeed3x()
    {
        Time.timeScale = 3;
    }
    
    [MenuItem("Tools/Game Speed/Time speed 5x")]
    public static void UpdateTimeSpeed5x()
    {
        Time.timeScale = 5;
    }
    
    [MenuItem("Tools/Game Speed/Reset Time speed")]
    public static void UpdateTimeSpeedNormal()
    {
        Time.timeScale = 1;
    }
}
