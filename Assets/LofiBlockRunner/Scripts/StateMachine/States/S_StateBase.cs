/// <summary>  
/// Base state class, serves as a template for other states
/// </summary>
public abstract class S_StateBase
{
    public abstract void EnterState(S_StateMachine gameState);

    public abstract void LeaveState(S_StateMachine gameState);
}
