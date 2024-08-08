using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum ButtonType
{
    Switch_State_MainMenu,
    Switch_State_Game,
    Switch_State_Settings,
    Switch_State_Credits,
    Quit_Game,
    Open_Programmer_Url,
    Open_Sfx_Url,
    Open_Font_Url,
}

/// <summary>  
/// Handles button interactions like clicks, hover and etc
/// </summary>
[RequireComponent(typeof(Button))]
public class S_ButtonController : MonoBehaviour
{
    [SerializeField] private ButtonType _buttonType;

    Button uiButton;

    private void OnEnable()
    {
        uiButton = GetComponent<Button>();
        uiButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        switch (_buttonType)
        {
            case ButtonType.Switch_State_MainMenu:
                S_Actions.State_MainMenu(); break;
            case ButtonType.Switch_State_Game:
                S_Actions.State_Game(); break;
            case ButtonType.Switch_State_Settings:
                S_Actions.State_Settings(); break;
            case ButtonType.Switch_State_Credits:
                S_Actions.State_Credits(); break;
            case ButtonType.Quit_Game:
                Application.Quit(); break;
            case ButtonType.Open_Programmer_Url:
                Application.OpenURL("https://github.com/ArthurSegato"); break;
            case ButtonType.Open_Sfx_Url:
                Application.OpenURL("https://www.instagram.com/_lilopipa/"); break;
            case ButtonType.Open_Font_Url:
                Application.OpenURL("https://fonts.google.com/specimen/Roboto"); break;
        }
    }
}
