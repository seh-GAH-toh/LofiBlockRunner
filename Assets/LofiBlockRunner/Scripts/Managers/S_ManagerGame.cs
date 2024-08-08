using UnityEngine;

/// <summary>  
/// Initializes the initial states of various game objects.
/// </summary>
public class S_ManagerGame : MonoBehaviour
{
    private void OnEnable()
    {
        // Enter main menu state
        S_Actions.State_MainMenu();
        // Prevent player movement while on menus
        S_Actions.Player_Disable_Input();
        // Prevent obstacles spawning
        S_Actions.Obstacle_Disable_Manager();
    }
}
