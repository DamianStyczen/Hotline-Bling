using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour {

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject AuthorMenu;
    [SerializeField] GameObject HowToMenu;
    [SerializeField] GameObject currentMenu;

    public void onPlayButton()
    {
        
        SceneManager.LoadScene("Main_scene");
    }
    public void OnExitButton()
    {
        Application.Quit();
    }

    public void onBackButton()
    {
        MainMenu.SetActive(true);
        currentMenu.SetActive(false);

    }

    public void OnAuthorButton()
    {
        MainMenu.SetActive(false);
        AuthorMenu.SetActive(true);
        currentMenu = AuthorMenu;
    }
    public void onHowToButton()
    {
        MainMenu.SetActive(false);
        HowToMenu.SetActive(true);
        currentMenu = HowToMenu;
    }

}
