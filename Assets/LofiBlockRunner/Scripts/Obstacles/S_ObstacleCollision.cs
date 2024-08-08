using UnityEngine;

/// <summary>  
/// Handles obstacle destruction when colliding with barrier at the end of plataform
/// </summary>
public class S_ObstacleCollision : MonoBehaviour
{
    // Player reference
    [SerializeField] private GameObject _player;
    // Barrier reference
    [SerializeField] private GameObject _barrier;
    // Floor reference
    [SerializeField] private GameObject _floor;

    private bool _isPlayerCollisionEnabled = false;

    // Register collision triggers
    private void OnEnable()
    {
        S_Actions.Player_Enable_Collision += () => _isPlayerCollisionEnabled = true;
        S_Actions.Player_Disable_Collision += () => _isPlayerCollisionEnabled = false;
    }

    // Clear triggers
    private void OnDisable()
    {
        S_Actions.Player_Enable_Collision -= () => _isPlayerCollisionEnabled = true;
        S_Actions.Player_Disable_Collision -= () => _isPlayerCollisionEnabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == _player)
            HandlePlayerCollision();
        if(collision.gameObject == _barrier || collision.gameObject == _floor)
            HandleObstacleCollision();
    }

    private void HandlePlayerCollision()
    {
        /*
        * Check if player collision is enabled in order to avoid
        * colliding with the player again after the game already ended
        */
        if (_isPlayerCollisionEnabled) S_Actions.State_GameOver();
    }

    private void HandleObstacleCollision()
    {
        // Abort if there is no parent object
        if (transform.parent == null) 
        {
            Debug.LogWarning("Parent game object not found for obstacle collision.");
            return;
        }

        // Destroy obstacle
        Destroy(transform.parent.gameObject);
    }

}
