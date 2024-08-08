using UnityEngine;

/// <summary>  
/// Handles player position and rotation reset.
/// </summary>
public class S_PlayerReset : MonoBehaviour
{
    // Register trigger to reset player
    private void OnEnable() => S_Actions.Player_Reset_Position += ResetPlayer;
    
    // Clear trigger
    private void OnDisable() => S_Actions.Player_Reset_Position -= ResetPlayer;

    private void ResetPlayer()
    {
        // Resets the player's position to the origin (0, 0, 0)
        transform.position = Vector3.zero;
        // Resets the player's rotation to the identity rotation (no rotation)
        transform.rotation = Quaternion.identity;
    }
}
