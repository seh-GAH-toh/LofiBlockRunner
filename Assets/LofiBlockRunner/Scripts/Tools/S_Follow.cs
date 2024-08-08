using UnityEngine;

/// <summary>  
/// Follow another game object
/// </summary>
public class S_Follow : MonoBehaviour
{
    [Header("Follow Settings")]
    [Tooltip("Object to be followed.")]
    [SerializeField] private GameObject _target;
    
    private void LateUpdate() => transform.position = _target.transform.position;
}
