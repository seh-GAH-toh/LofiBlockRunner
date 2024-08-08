using UnityEngine;
using System.Collections;

/// <summary>  
/// Handles obstacle animation on game over by applying a dissolve shader effect.
/// </summary>
public class S_ObstacleAnimation : MonoBehaviour
{
    [Header("Shader Config")]
    [Tooltip("Material with the dissolve shader effect")]
    [SerializeField] private Material _material;
    
    [Tooltip("Delay before starting the shader animation")]
    [SerializeField] private float _delay = 2.5f;

    [Tooltip("Speed of the shader animation")]
    [SerializeField] private float _speed = 0.025f;

    // Dissolve effect intensity
    private float _intensity = 0.15f;

    // Register animation trigger 
    private void OnEnable() => S_Actions.Obstacle_Animate += () => StartCoroutine(Dissolve());
    
    // Clear trigger
    private void OnDisable() => S_Actions.Obstacle_Animate -= () => StartCoroutine(Dissolve());

    private IEnumerator Dissolve()
    {
        // Ensure material exists and was not "dissolved"
        if (_material == null || _material.GetFloat("_Dissolve") >= 1f) yield break;

        // Wait for the specified time before starting the animation
        yield return new WaitForSeconds(_delay);

        // Increment the dissolve effect intensity until it reaches its maximum value
        while (_intensity < 1f)
        {
            _intensity += _speed * Time.deltaTime;
            _material.SetFloat("_Dissolve", _intensity);
            yield return null;
        }
    }
}
