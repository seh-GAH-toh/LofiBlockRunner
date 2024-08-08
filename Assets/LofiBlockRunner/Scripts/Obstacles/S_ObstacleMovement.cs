using UnityEngine;

/// <summary>  
/// Handles obstacles movement.
/// </summary>
public class S_ObstacleMovement : MonoBehaviour
{
    [Tooltip("Obstacle RigidBody.")]
    [SerializeField] private Rigidbody _rb;

    [Header("Movement Settings")]
    [Tooltip("Speed of the obstacle.")]
    [SerializeField] private float _speed = 1000f;

    private bool _isGameEnded = false;

    // Register trigger to disable obstacle movement
    private void OnEnable() => S_Actions.Obstacle_Disable_Movement += () => _isGameEnded = true;
    
    // Clear trigger
    private void OnDisable() => S_Actions.Obstacle_Disable_Movement -= () => _isGameEnded = true;
    
    private void FixedUpdate()
    {
        while (!_isGameEnded)
            _rb.AddForce(_speed * Vector3.back * Time.deltaTime);
        /* 
        *   Check if obstacles stop smoothy cuting the add force
        *   if not, then use code below to make it stop on a smoth way
        *   keep in mind of possible overheat of dividing very small numbers
        *   _rb.velocity = _rb.velocity / _stoppingSpeed;
        */
    }
}
