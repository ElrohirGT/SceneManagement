using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class LoadingMenu : MonoBehaviour
{
    private VisualElement _preview;
    private ProgressBar _bar;

    public List<string> phrases = new();
    
    private void Awake()
    {
        var r = new Random();
        var ui = GetComponent<UIDocument>();
        _preview = ui.rootVisualElement.Q<VisualElement>("preview");
        _bar = ui.rootVisualElement.Q<ProgressBar>("bar");

        var phrase = phrases[r.Next(phrases.Count)];
        ui.rootVisualElement.Q<Label>("phrase").text = phrase;
    }

    private void OnEnable()
    {
        EventBus.LoadingProgressChanged += EventBusOnLoadingProgressChanged;
    }

    

    private void OnDisable()
    {
        EventBus.LoadingProgressChanged -= EventBusOnLoadingProgressChanged;
    }

    public void SetLevelInfo(LevelInfo obj)
    {
        _preview.dataSource = obj;
    }
    
    private void EventBusOnLoadingProgressChanged(float obj)
    {
        _bar.value = obj;
    }
}
