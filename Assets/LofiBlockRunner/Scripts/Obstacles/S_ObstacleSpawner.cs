using UnityEngine;
using System.Collections;

/// <summary>  
/// Handles obstacle spawning.
/// </summary>
public class S_ObstacleSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [Tooltip("List with all obstacles to be spawned.")]
    [SerializeField] private GameObject[] _obstacles;

    [Tooltip("How many seconds to wait before start spawning obstacles.")]
    [SerializeField] private float _delay = 0.0f;

    [Tooltip("Interval in seconds between spawning of each obstacle.")]
    [SerializeField] private float _interval = 0.0f;

    private void OnEnable()
    {
        // Register triggers to enable or disable the spawner
        S_Actions.Obstacle_Enable_Manager += () => StartCoroutine(SpawnObstacles());
        S_Actions.Obstacle_Disable_Manager += () => StopCoroutine(SpawnObstacles());
    }

    private void OnDisable()
    {
        // Clear triggers when closing the game
        S_Actions.Obstacle_Enable_Manager -= () => StartCoroutine(SpawnObstacles());
        S_Actions.Obstacle_Disable_Manager -= () => StopCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        // Wait for the initial delay
        yield return new WaitForSeconds(_delay);

        // Start spawning
        while (true)
        {
            // Get random obstacle from list
            int index = Random.Range(0, _obstacles.Length);
            
            // Calculate his spawn position
            Vector3 spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), 0.0f, 0.0f);

            // Spawn object
            Instantiate(_obstacles[index], spawnPosition, Quaternion.identity);

            // Wait a few seconds before starting again
            yield return new WaitForSeconds(_interval);
        }
        
    }
}
