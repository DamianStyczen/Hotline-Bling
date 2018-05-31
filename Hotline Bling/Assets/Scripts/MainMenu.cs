using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField] GameObject MainMenuObject;
    [SerializeField] GameObject AuthorMenu;
    [SerializeField] GameObject HowToMenu;
    [SerializeField] GameObject currentMenu;

    private void Start()
    {
        Cursor.visible = true;
    }

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
        MainMenuObject.SetActive(true);
        currentMenu.SetActive(false);

    }

    public void OnAuthorButton()
    {
        MainMenuObject.SetActive(false);
        AuthorMenu.SetActive(true);
        currentMenu = AuthorMenu;
    }
    public void onHowToButton()
    {
        MainMenuObject.SetActive(false);
        HowToMenu.SetActive(true);
        currentMenu = HowToMenu;
    }

}
