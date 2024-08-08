using UnityEngine;

/// <summary>  
/// State Machine, handles all states changes
/// </summary>
public class S_StateMachine : MonoBehaviour
{
    private S_StateBase _currentState;

    private S_StateIntro _stateIntro = new S_StateIntro();
    private S_StateMainMenu _stateMainMenu = new S_StateMainMenu();
    private S_StateSettings _stateSettings = new S_StateSettings();
    private S_StateCredits _stateCredits = new S_StateCredits();
    private S_StateGame _stateGame = new S_StateGame();
    private S_StateGameOver _stateGameOver = new S_StateGameOver();
    private S_StateTutorial _stateTutorial = new S_StateTutorial();
    private S_StatePause _statePause = new S_StatePause();

    // Register triggers
    private void OnEnable()
    {
        S_Actions.State_Tutorial += () => SwitchState(_stateTutorial);
        S_Actions.State_MainMenu += () => SwitchState(_stateMainMenu);
        S_Actions.State_Settings += () => SwitchState(_stateSettings);
        S_Actions.State_Credits += () => SwitchState(_stateCredits);
        S_Actions.State_Game += () => SwitchState(_stateGame);
        S_Actions.State_Pause += () => SwitchState(_statePause);
        S_Actions.State_GameOver += () => SwitchState(_stateGameOver);
    }

    // Clear triggers
    private void OnDisable()
    {
        S_Actions.State_Tutorial -= () => SwitchState(_stateTutorial);
        S_Actions.State_MainMenu -= () => SwitchState(_stateMainMenu);
        S_Actions.State_Settings -= () => SwitchState(_stateSettings);
        S_Actions.State_Credits -= () => SwitchState(_stateCredits);
        S_Actions.State_Game -= () => SwitchState(_stateGame);
        S_Actions.State_Pause -= () => SwitchState(_statePause);
        S_Actions.State_GameOver -= () => SwitchState(_stateGameOver);
    }

    // Switch between states
    private void SwitchState(S_StateBase newState)
    {
        // Leave old state, if any
        if(_currentState != null ) _currentState.LeaveState(this);
        // Set new state as current
        _currentState = newState;
        // Enter new state
        newState.EnterState(this);
    }
}
