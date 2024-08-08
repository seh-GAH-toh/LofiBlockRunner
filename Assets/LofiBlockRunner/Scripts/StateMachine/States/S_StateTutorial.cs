/// <summary>  
/// Title Screen state, handles player input, camera and  ui
/// </summary>
public class S_StateTutorial : S_StateBase
{
    public override void EnterState(S_StateMachine gameState)
    {
        S_Actions.Player_Enable_Input();
        S_Actions.Camera_Enable_Game();
        S_Actions.Player_Enable_Tutorial();
        S_Actions.UI_Enable_Tutorial();
    }
    public override void LeaveState(S_StateMachine gameState)
    {
        S_Actions.Player_Disable_Input();
        S_Actions.Player_Disable_Tutorial();
    }
}
