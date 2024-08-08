using System;

/// <summary>  
/// Class containing all game actions
/// </summary>
public static class S_Actions
{
    #region States
    public static Action State_Tutorial;

    public static Action State_MainMenu;

    public static Action State_Settings;

    public static Action State_Credits;

    public static Action State_Game;

    public static Action State_Pause;

    public static Action State_GameOver;
    #endregion

    #region Obstacles
    public static Action Obstacle_Enable_Manager;

    public static Action Obstacle_Disable_Manager;

    public static Action Obstacle_Destroy;

    public static Action Obstacle_Animate;

    public static Action Obstacle_Disable_Movement;

    public static Action Obstacle_Spawned_Flag;

    public static Action Obstacle_Destroyed_Flag;
    #endregion

    #region Player
    public static Action Player_Reset_Position;

    public static Action Player_Swap_Mesh;

    public static Action Player_Enable_Input;

    public static Action Player_Disable_Input;

    public static Action Player_Enable_Collision;

    public static Action Player_Disable_Collision;

    public static Action Player_Enable_Pause;

    public static Action Player_Disable_Pause;

    public static Action Player_Enable_Tutorial;

    public static Action Player_Disable_Tutorial;
    #endregion

    #region Camera
    public static Action Camera_Enable_MainMenu;

    public static Action Camera_Enable_Settings;

    public static Action Camera_Enable_Credits;

    public static Action Camera_Enable_Game;
    #endregion

    #region UI
    public static Action UI_Enable_Tutorial;

    public static Action UI_Enable_MainMenu;

    public static Action UI_Enable_Settings;

    public static Action UI_Enable_Credits;

    public static Action UI_Enable_Game;

    public static Action UI_Enable_Pause;

    public static Action UI_Enable_GameOver;
    #endregion
}
