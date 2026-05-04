using System;
using ScriptableObjects;

public static class EventBus
{
    public static event Action<LevelInfo> LevelInfoChanged;
    public static event Action<float> LoadingProgressChanged;

    public static void OnLevelInfoChanged(LevelInfo obj)
    {
        LevelInfoChanged?.Invoke(obj);
    }

    public static void OnLoadingProgressChanged(float obj)
    {
        LoadingProgressChanged?.Invoke(obj);
    }
}
