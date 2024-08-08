using UnityEngine;

/// <summary>  
/// Swap player mesh between 
/// </summary>
public class S_PlayerMeshChanger : MonoBehaviour
{
    [Header("Mesh Settings")]
    [Tooltip("Original Mesh")]
    [SerializeField] private GameObject _originalMesh;

    [Tooltip("Broken Mesh")]
    [SerializeField] private GameObject _brokenMesh;

    private bool _lastState = false;

    // Register triggers for mesh swap
    private void OnEnable()
    {
        S_Actions.Player_Swap_Mesh += SwapMesh;
    }
    private void OnDisable()
    {
        S_Actions.Player_Swap_Mesh -= SwapMesh;
    }

    private void SwapMesh()
    {
        // Swap mesh state
        _lastState = !_lastState;

        // Update player
        _originalMesh.SetActive(_lastState);
        _brokenMesh.SetActive(!_lastState);
    }
}
