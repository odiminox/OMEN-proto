using UnityEngine;

namespace OMEN.Logging
{
    public static class Logger
    {
        public static bool enabled = true;

        // TODO log into Unity and also custom log file in mod Game directory
        public static void LogError(string message)
        {
            if (enabled)
            {
               Debug.LogError(message); 
            }
        }

        public static void LogWarning(string message)
        {
            if (enabled)
            {
               Debug.LogWarning(message); 
            }
        }

        public static void LogInfo(string message)
        {
            if (enabled)
            {
               Debug.Log(message); 
            }
        }
    }
}