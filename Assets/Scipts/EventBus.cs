using System;
using ScriptableObjects;
using UnityEngine;

public static class EventBus
{
    public static event Action<LevelInfo> LevelInfoChanged;
    public static event Action<float> LoadingProgressChanged;
    public static event Action<string> LevelLoadedFromMainMenu;

    public static event Action<Vector3> TeleportPlayer;

    public static void OnLevelInfoChanged(LevelInfo obj)
    {
        LevelInfoChanged?.Invoke(obj);
    }

    public static void OnLoadingProgressChanged(float obj)
    {
        LoadingProgressChanged?.Invoke(obj);
    }

    public static void OnLevelLoadedFromMainMenu(string level)
    {
        LevelLoadedFromMainMenu?.Invoke(level);
    }

    public static void OnTeleportPlayer(Vector3 obj)
    {
        TeleportPlayer?.Invoke(obj);
    }
}
