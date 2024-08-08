using UnityEngine;
/// <summary>  
/// Pause state, handles time freeze, and pause ui
/// </summary>
public class S_StatePause : S_StateBase
{
    public override void EnterState(S_StateMachine gameState)
    {
        S_Actions.Camera_Enable_Game();
        S_Actions.UI_Enable_Pause();
        Time.timeScale = 0f;
    }

    public override void LeaveState(S_StateMachine gameState)
    {
        Time.timeScale = 1.0f;
    }
}
