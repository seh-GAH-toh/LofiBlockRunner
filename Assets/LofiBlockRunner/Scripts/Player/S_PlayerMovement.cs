using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>  
/// Class responsible for the player`s movement, has 2 functions,
/// the first one "Fixed Update" updates the player current position
/// the second on "OnMove" listen for input data, aka, keys pressed
/// </summary>
public class S_PlayerMovement : MonoBehaviour
{
    [Tooltip("Player RigidBody.")]
    [SerializeField] private Rigidbody _rb;
    
    [Header("Movement")]
    [Tooltip("Speed of the lateral movement of the block.")]
    [SerializeField] private float _speed = 500f;
    
    private bool _isPaused = false;
    private bool _isTutorial = false;
    private Vector2 _movementInput;

    // Register player movement triggers
    private void OnEnable()
    {
        S_Actions.Player_Enable_Input += () => enabled = true;
        S_Actions.Player_Disable_Input += () => enabled = false;
        S_Actions.Player_Enable_Pause += () => _isPaused = true;
        S_Actions.Player_Disable_Pause += () => _isPaused = false;
        S_Actions.Player_Enable_Tutorial += () => _isTutorial = true;
        S_Actions.Player_Disable_Tutorial += () => _isTutorial = false;
    }

    // Clear triggers
    private void OnDisable()
    {
        S_Actions.Player_Enable_Input -= () => enabled = true;
        S_Actions.Player_Disable_Input -= () => enabled = false;
        S_Actions.Player_Enable_Pause -= () => _isPaused = true;
        S_Actions.Player_Disable_Pause -= () => _isPaused = false;
        S_Actions.Player_Enable_Tutorial -= () => _isTutorial = true;
        S_Actions.Player_Disable_Tutorial -= () => _isTutorial = false;
    }

    // When player hit pause button, then pause game
    private void OnPause() 
    {
        if (_isPaused == true) S_Actions.State_Pause();
    }

    // When player press the confirm button, start game
    private void OnConfirm()
    {
        if(_isTutorial == true) S_Actions.State_Game();
    }

    // When player press the lateral movement keys, move the block
    private void OnMove(InputValue value) => _movementInput = value.Get<Vector2>();

    // Update player position
    private void FixedUpdate() => _rb.AddForce(_speed * new Vector3(_movementInput.x, 0, _movementInput.y) * Time.deltaTime);
}
