using UnityEngine;
using System;

public enum CanvasType
{
    MainMenu,
    Settings,
    Credits,
    Tutorial,
    Game,
    GameOver
}

/// <summary>  
/// Handles UI behavior
/// </summary>
public class S_UIManager : MonoBehaviour
{
    [SerializeField] private S_CanvasController[] _canvasList;
    private S_CanvasController _lastActiveCanvas;

    private void Awake()
    {
        // Hidde all canvas on game open to prevent overheat
        foreach (S_CanvasController canvas in _canvasList) canvas.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        // Register canvas triggers
        S_Actions.UI_Enable_MainMenu += () => SwitchCanvas(CanvasType.MainMenu);
        S_Actions.UI_Enable_Settings += () => SwitchCanvas(CanvasType.Settings);
        S_Actions.UI_Enable_Credits += () => SwitchCanvas(CanvasType.Credits);
        S_Actions.UI_Enable_Tutorial += () => SwitchCanvas(CanvasType.Tutorial);
        S_Actions.UI_Enable_Game += () => SwitchCanvas(CanvasType.Game);
        S_Actions.UI_Enable_GameOver += () => SwitchCanvas(CanvasType.GameOver);
    }

    // Clear triggers
    private void OnDisable()
    {
        S_Actions.UI_Enable_MainMenu -= () => SwitchCanvas(CanvasType.MainMenu);
        S_Actions.UI_Enable_Settings -= () => SwitchCanvas(CanvasType.Settings);
        S_Actions.UI_Enable_Credits -= () => SwitchCanvas(CanvasType.Credits);
        S_Actions.UI_Enable_Tutorial -= () => SwitchCanvas(CanvasType.Tutorial);
        S_Actions.UI_Enable_Game -= () => SwitchCanvas(CanvasType.Game);
        S_Actions.UI_Enable_GameOver -= () => SwitchCanvas(CanvasType.GameOver);
    }

    public void SwitchCanvas(CanvasType _type)
    {
        // Search for the desired camera
        S_CanvasController desiredCanvas = Array.Find(_canvasList,x => x.canvasType == _type);
        
        // If dind find it, exit earlier and throw warning 
        if (desiredCanvas == null)
        {
            Debug.LogWarning("The desired canvas was not found!");
            return;
        }
        
        // Turn off the last canvas
        if (_lastActiveCanvas != null) _lastActiveCanvas.gameObject.SetActive(false);
        // Update last camera
        _lastActiveCanvas = desiredCanvas;
        // Turn on desired canvas
        desiredCanvas.gameObject.SetActive(true);
    }
}
