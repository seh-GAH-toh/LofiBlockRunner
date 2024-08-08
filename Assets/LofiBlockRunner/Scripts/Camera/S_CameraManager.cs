using UnityEngine;
using System;

// List of camera types
public enum CameraType
{
    MainMenu,
    Settings,
    Credits,
    Game
}

/// <summary>  
/// Manages the logic for controlling cameras within the scene.
/// </summary>
public class S_CameraManager : MonoBehaviour
{
    // List of cameras in the scene
    [SerializeField] private S_CameraController[] _cameraList;

    // Reference to the last active camera
    private S_CameraController _lastActiveCamera;

    // Disable all cameras during initialization to avoid overheat
    private void Awake()
    {
        foreach (S_CameraController camera in _cameraList)
        {
            camera.gameObject.SetActive(false);
        }
    }

    // Register camera triggers
    private void OnEnable()
    {
        S_Actions.Camera_Enable_MainMenu += () => SwitchCamera(CameraType.MainMenu);
        S_Actions.Camera_Enable_Settings += () => SwitchCamera(CameraType.Settings);
        S_Actions.Camera_Enable_Credits += () => SwitchCamera(CameraType.Credits);
        S_Actions.Camera_Enable_Game += () => SwitchCamera(CameraType.Game);
    }

    // Clear triggers
    private void OnDisable()
    {
        S_Actions.Camera_Enable_MainMenu -= () => SwitchCamera(CameraType.MainMenu);
        S_Actions.Camera_Enable_Settings -= () => SwitchCamera(CameraType.Settings);
        S_Actions.Camera_Enable_Credits -= () => SwitchCamera(CameraType.Credits);
        S_Actions.Camera_Enable_Game -= () => SwitchCamera(CameraType.Game);
    }

    private void SwitchCamera(CameraType _type)
    {
        // Find the desired camera in the camera list
        S_CameraController desiredCamera = Array.Find(_cameraList, x => x.cameraType == _type);

        // If the desired camera is not found, log a warning and exit the method
        if (desiredCamera == null)
        {
            Debug.LogWarning("The desired camera was not found!");
            return;
        }
        
        // Turn off the previously active camera, if any
        if (_lastActiveCamera != null)
        {
            _lastActiveCamera.gameObject.SetActive(false);
        }
        
        // Update the reference to the last active camera
        _lastActiveCamera = desiredCamera;
        
        // Turn on the desired camera
        desiredCamera.gameObject.SetActive(true);
    }
}