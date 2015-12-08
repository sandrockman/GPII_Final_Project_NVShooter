using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class NewMainMenuScript : NetworkBehaviour {

    enum CanvasSetting
    {
        MAIN,
        CREATE,
        JOIN
    };

    public Canvas mainMenu;
    public Canvas createMenu;
    public Canvas joinMenu;

    CanvasSetting menuSetting;

    public NetworkManager manager;
    public Text levelSelect;

	// Use this for initialization
	void Start () {
        menuSetting = CanvasSetting.MAIN;
	}

    public void _MenuCreateGame()
    {
        createMenu.enabled = true;
        mainMenu.enabled = false;
        menuSetting = CanvasSetting.CREATE;
    }

    public void _MenuJoinGame()
    {
        joinMenu.enabled = true;
        mainMenu.enabled = false;
        menuSetting = CanvasSetting.JOIN;
    }

    public void _QuitGame()
    {
        Application.Quit();
    }

    public void _BackToMainMenu()
    {
        mainMenu.enabled = true;
        createMenu.enabled = false;
        joinMenu.enabled = false;
        menuSetting = CanvasSetting.MAIN;
    }

    public void _CreateHostGame()
    {
        manager.StartHost();
    }

    public void _JoinHostGame()
    {
        manager.StartClient();
    }

    public void _UpdateHostName(InputField newHostname)
    {
        if(String.IsNullOrEmpty(newHostname.text))
        {
            manager.networkAddress = "localhost";
        }
        else
        {
            manager.networkAddress = newHostname.text;
        }
    }

    public void _UpdatePortNumber(InputField intStep)
    {
        int newPort;
        if (Int32.TryParse(intStep.text, out newPort))
        {
            manager.networkPort = newPort;
        }
        else
        {
            manager.networkPort = 7777;
        }
    }

    public void _LevelChange()
    {
        if(manager.onlineScene == "Level1")
        {
            manager.onlineScene = "Level2";
            levelSelect.text = "Level 2";
        }
        else
        {
            manager.onlineScene = "Level1";
            levelSelect.text = "Level 1";
        }
    }
}
