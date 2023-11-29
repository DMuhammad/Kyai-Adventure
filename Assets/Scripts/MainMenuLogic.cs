using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public GameObject PanelMainMenu;
    public GameObject PanelOption;
    public GameObject Back;

    public void OpenOption()
    {
        PanelMainMenu.SetActive(false);
        PanelOption.SetActive(true);
    }

    public void BackOption()
    {
        PanelMainMenu.SetActive(true);
        PanelOption.SetActive(false);
    }
    public void OpenGamePlay()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    void Start()
    {

    }

    public void startgamebutton()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
