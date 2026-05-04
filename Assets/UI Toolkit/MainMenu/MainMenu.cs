using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public List<LevelInfo> levels;
    public int currentLevel = 0;

    private Button _leftBtn;
    private Button _rightBtn;
    private Button _playBtn;
    private Button _quitBtn;

    private VisualElement _preview;
    public LoadingMenu loadingUI;

    private LevelInfo Current => levels[currentLevel];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        var ui = GetComponent<UIDocument>();
        _leftBtn = ui.rootVisualElement.Q<Button>("leftBtn");
        _rightBtn = ui.rootVisualElement.Q<Button>("rightBtn");
        _preview = ui.rootVisualElement.Q<VisualElement>("preview");
        
        _playBtn = ui.rootVisualElement.Q<Button>("playBtn");
        _quitBtn = ui.rootVisualElement.Q<Button>("quitBtn");
    }

    private void OnEnable()
    {
        _leftBtn.clicked += LeftBtnOnclicked;
        _rightBtn.clicked += RightBtnOnclicked;
        _playBtn.clicked += PlayBtnOnclicked;
        _quitBtn.clicked += QuitBtnOnclicked;
    }

    

    private void OnDisable()
    {
        _leftBtn.clicked -= LeftBtnOnclicked;
        _rightBtn.clicked -= RightBtnOnclicked;
        _playBtn.clicked -= PlayBtnOnclicked;
        _quitBtn.clicked -= QuitBtnOnclicked;
    }

    private void PlayBtnOnclicked()
    {
        StartCoroutine(LoadSceneAsync(Current.sceneName));
    }
    
    private void QuitBtnOnclicked()
    {
        Application.Quit();
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        var op = SceneManager.LoadSceneAsync(sceneName);
        loadingUI.gameObject.SetActive(true);
        loadingUI.SetLevelInfo(Current);
        UnityAction<Scene, LoadSceneMode> h = (arg0, mode) =>
        {
            if (arg0.name != sceneName) return;
            
            SceneManager.LoadScene("PlayerScene", LoadSceneMode.Additive);
            Manager.Instance.LevelLoadedFromMenu = arg0.name;
        };
        
        SceneManager.sceneLoaded += h;

        while (op is { isDone: false })
        {
            var progress = Mathf.Clamp01(op.progress / 0.9f);
            EventBus.OnLoadingProgressChanged(progress);
            yield return null;
        }

        SceneManager.sceneLoaded -= h;
    }

    private void RightBtnOnclicked()
    {
        currentLevel++;
        if (currentLevel >= levels.Count)
        {
            currentLevel = levels.Count - 1;
        }
        UpdateCurrentLevel();
    }

    private void LeftBtnOnclicked()
    {
        currentLevel--;
        if (currentLevel <= 0)
        {
            currentLevel = 0;
        }

        UpdateCurrentLevel();
    }

    private void UpdateCurrentLevel()
    {
        var info = levels[currentLevel];
        _preview.dataSource = info;
        EventBus.OnLevelInfoChanged(info);
    }
}
