using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += SceneManagerOnsceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManagerOnsceneLoaded;
    }

    private void SceneManagerOnsceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SceneManager.sceneLoaded -= SceneManagerOnsceneLoaded;

        if (Manager.Instance.LevelLoadedFromMenu != gameObject.scene.name) return;
        Debug.Log("Firing teleport event!");
        EventBus.OnTeleportPlayer(gameObject.transform.position);
    }
}
