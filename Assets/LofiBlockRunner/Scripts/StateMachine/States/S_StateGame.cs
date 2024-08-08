/// <summary>  
/// Handles obstacles spawning, player collision, camera and ui
/// </summary>
public class S_StateGame : S_StateBase
{
    public override void EnterState(S_StateMachine gameState)
    {
        S_Actions.Obstacle_Enable_Manager();
        S_Actions.UI_Enable_Game();
        S_Actions.Camera_Enable_Game();
        S_Actions.Player_Enable_Input();
        S_Actions.Player_Enable_Pause();
        
    }
    public override void LeaveState(S_StateMachine gameState)
    {
        S_Actions.Obstacle_Disable_Manager();
        S_Actions.Player_Disable_Collision();
        S_Actions.Player_Disable_Input();
        S_Actions.Player_Disable_Pause();
    }
}
