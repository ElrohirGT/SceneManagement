using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string LevelLoadedFromMenu { get; set; }
}