using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject mainMenu;

    [SerializeField] Button Resume;
    [SerializeField] Button Restart;
    [SerializeField] Button Settings;
    [SerializeField] Button Save;
    [SerializeField] Button Exit;

    // Start is called before the first frame update
    void Start()
    {
        settingsMenu.SetActive(false);
        Resume.onClick.AddListener(CloseMainMenu);
        Restart.onClick.AddListener(CloseMainMenu);
        Settings.onClick.AddListener(OpenSettingsMenu);
        Save.onClick.AddListener(CloseMainMenu);
        Exit.onClick.AddListener(CloseMainMenu);
    }

    void OpenSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void CloseMainMenu()
    {
        mainMenu.SetActive(false);
    }
}

