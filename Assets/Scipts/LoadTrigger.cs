using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTrigger : MonoBehaviour
{
    public string transitionScene;
    public string nextScene;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        SceneManager.LoadScene(transitionScene, LoadSceneMode.Additive);
        StartCoroutine(LoadSceneAsync(nextScene));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        var op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!op.isDone)
        {
            yield return null;
        }
        Debug.Log("Done loading second scene!");
        Destroy(gameObject);
    }
}