/// <summary>  
/// Title Screen state, handles player input, camera and  ui
/// </summary>
public class S_StateMainMenu : S_StateBase
{
    private bool _hasObstaclesSpawned = false;

    private void OnEnable()
    {
        S_Actions.Obstacle_Spawned_Flag += () => _hasObstaclesSpawned = true;
        S_Actions.Obstacle_Destroyed_Flag += () => _hasObstaclesSpawned = false;
    }
    
    private void OnDisable()
    {
        S_Actions.Obstacle_Spawned_Flag -= () => _hasObstaclesSpawned = true;
        S_Actions.Obstacle_Destroyed_Flag -= () => _hasObstaclesSpawned = false;
    }
    
    public override void EnterState(S_StateMachine gameState)
    {
        S_Actions.Camera_Enable_MainMenu();
        S_Actions.UI_Enable_MainMenu();
        //S_Actions.Player_Reset_Position();
        //if (_hasObstaclesSpawned) S_Actions.Obstacle_Destroy();
    }

    public override void LeaveState(S_StateMachine gameState)
    {
    }
}
