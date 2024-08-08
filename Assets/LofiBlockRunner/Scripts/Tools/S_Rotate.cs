using UnityEngine;

public enum Direction
{
    Right,
    Left
}

/// <summary>  
/// Rotate a object
/// </summary>
public class S_Rotate : MonoBehaviour
{
    [Header("Anchor Settings")]
    [Tooltip("Direction in wich the anchor will rotate.")]
    [SerializeField] private Direction _direction = Direction.Right;

    [Tooltip("Speed in wich the anchor will rotate.")]
    [SerializeField] private float _speed = 0f;

    private float _desiredDirection = 1f;

    // Update the desired direction
    private void OnEnable()
    {
        if(_direction == Direction.Left) _desiredDirection = -1f;
    }

    // Rotate object on desired direction
    private void Update() => transform.eulerAngles += new Vector3(0, _desiredDirection * _speed * Time.unscaledDeltaTime, 0);
}