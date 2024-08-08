using UnityEngine;
/// <summary>  
/// Settings state, handles time freeze, options camera and ui
/// </summary>
public class S_StateSettings : S_StateBase
{
    public override void EnterState(S_StateMachine gameState)
    {
        S_Actions.Camera_Enable_Settings();
        S_Actions.UI_Enable_Settings();
        Time.timeScale = 0f;
    }

    public override void LeaveState(S_StateMachine gameState)
    {
        Time.timeScale = 1.0f;
    }
}
