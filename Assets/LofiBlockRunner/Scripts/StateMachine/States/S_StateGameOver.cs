/// <summary>  
/// GameOver state, handles obstacles spawning, player input, camera and ui
/// </summary>
public class S_StateGameOver : S_StateBase
{
    public override void EnterState(S_StateMachine gameState)
    {
        S_Actions.UI_Enable_GameOver();
        S_Actions.Camera_Enable_Game();
        S_Actions.Player_Disable_Input();
        S_Actions.Player_Disable_Collision();
        S_Actions.Player_Swap_Mesh();
        S_Actions.Obstacle_Disable_Movement();
        S_Actions.Obstacle_Animate();
    }

    public override void LeaveState(S_StateMachine gameState)
    {
        S_Actions.Player_Reset_Position();
        S_Actions.Player_Enable_Input();
        S_Actions.Player_Enable_Collision();
        S_Actions.Obstacle_Destroy();
    }
}
