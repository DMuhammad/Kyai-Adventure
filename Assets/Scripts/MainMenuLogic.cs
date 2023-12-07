using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public GameObject PanelMainMenu;
    public GameObject PanelAbout;
    public GameObject Panelhowtoplay;
    public GameObject Back;

    public void OpenAbout()
    {
        if (PanelMainMenu.activeSelf)
        {
        // Jika PanelMainMenu sedang aktif, tampilkan PanelSetting
            PanelMainMenu.SetActive(false);
            PanelAbout.SetActive(true);
        }
        else if (PanelAbout.activeSelf)
        {
        // Jika PanelAbout sedang aktif, lakukan sesuatu jika diperlukan
        // Misalnya, kembalikan ke menu utama atau lakukan operasi lain
            PanelAbout.SetActive(false);
        // ...
        }

    }

    public void BackAbout()
    {
        PanelMainMenu.SetActive(true);
        PanelAbout.SetActive(false);

        if (Panelhowtoplay.activeSelf)
        {
            PanelMainMenu.SetActive(true);
            PanelAbout.SetActive(false);;
            Back.SetActive(false);
        }
        else if (PanelAbout.activeSelf)
        {
        // Kembalikan ke PanelAbout jika PanelSetting tidak aktif
            PanelMainMenu.SetActive(false);
            PanelAbout.SetActive(true);
            Back.SetActive(true);
        }
    }

    
    public void OpenGamePlay()
    {
        SceneManager.LoadScene("MazeScene");
    }

    void Start()
    {

    }

    public void startgamebutton()
    {
        SceneManager.LoadScene("GameplayMaze");
    }


public void Openhowtoplay()
    {
        if (PanelMainMenu.activeSelf)
        {
        // Jika PanelMainMenu sedang aktif, tampilkan PanelSetting
            PanelMainMenu.SetActive(false);
            Panelhowtoplay.SetActive(true);
        }
        else if (Panelhowtoplay.activeSelf)
        {
        // Jika PanelAbout sedang aktif, lakukan sesuatu jika diperlukan
        // Misalnya, kembalikan ke menu utama atau lakukan operasi lain
            Panelhowtoplay.SetActive(false);
        // ...
        }

    }

   public void Backhowtoplay()
    {
        PanelMainMenu.SetActive(true);
        Panelhowtoplay.SetActive(false);

        if (PanelAbout.activeSelf)
        {
            PanelMainMenu.SetActive(true);
            Panelhowtoplay.SetActive(false);;
            Back.SetActive(false);
        }
        else if (Panelhowtoplay.activeSelf)
        {
        // Kembalikan ke PanelAbout jika PanelSetting tidak aktif
            PanelMainMenu.SetActive(false);
            Panelhowtoplay.SetActive(true);
            Back.SetActive(true);
        }
    }
}