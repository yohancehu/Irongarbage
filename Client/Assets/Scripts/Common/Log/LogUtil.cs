using UnityEngine;

public class LogUtil
{
    public static bool useLog = true;
    private const string COLOR_FORMAT = "<color=#{0}>{1}</color>";

    public static void Log(object obj,Color color)
    {
        if (useLog)
        {
            Debug.Log(GetColorStr(obj.ToString(), color));
        }
    }
    public static void Log(object obj)
    {
        if (useLog)
        {
            Debug.Log(obj.ToString());
        }
    }
    public static void LogWarning(object obj, Color color)
    {
        if (useLog)
        {
            Debug.LogWarning(GetColorStr(obj.ToString(), color));
        }
    }
    public static void LogWarning(object obj)
    {
        if (useLog)
        {
            Debug.LogWarning(obj.ToString());
        }
    }
    public static void LogError(object obj, Color color)
    {
        if (useLog)
        {
            Debug.LogError(GetColorStr(obj.ToString(), color));
        }
    }
    public static void LogError(object obj)
    {
        if (useLog)
        {
            Debug.LogError(obj.ToString());
        }
    }

    private static string GetColorStr(object obj, Color color)
    {
        string stringRGB = ColorUtility.ToHtmlStringRGB(color);
        return string.Format(COLOR_FORMAT, stringRGB, obj.ToString());
    }
}
