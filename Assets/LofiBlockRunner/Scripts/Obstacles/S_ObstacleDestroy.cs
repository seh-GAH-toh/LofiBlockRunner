using UnityEngine;

/// <summary>  
/// Handles obstacle destruction on game over.
/// </summary>
public class S_ObstacleDestroy : MonoBehaviour
{
    // Register trigger to destroy the obstacle
    private void OnEnable() => S_Actions.Obstacle_Destroy += DestroyObstacle;

    // Clear trigger
    private void OnDisable() => S_Actions.Obstacle_Destroy -= DestroyObstacle;

    private void DestroyObstacle()
    {
        // Ensure that the parent game object exists before destroying it
        if (transform.parent == null)
        {
            Debug.LogWarning("Parent game object not found for obstacle destruction.");
            return;
        }
        
        Destroy(transform.parent.gameObject);
    }
}
