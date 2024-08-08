/// <summary>  
/// Handles credits camera and ui
/// </summary>
public class S_StateCredits : S_StateBase
{
    public override void EnterState(S_StateMachine gameState)
    {
        S_Actions.Camera_Enable_Credits();
        S_Actions.UI_Enable_Credits();
    }

    public override void LeaveState(S_StateMachine gameState)
    {
    }
}
