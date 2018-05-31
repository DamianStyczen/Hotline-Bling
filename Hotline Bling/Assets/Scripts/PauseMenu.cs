using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] GameObject MiddleScreenText;
    [SerializeField] GameObject WeaponText;



    // Use this for initialization
    private void OnDisable()
    {
        MiddleScreenText.SetActive(true);
        WeaponText.SetActive(true);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
    private void OnEnable()
    {
        MiddleScreenText.SetActive(false);
        WeaponText.SetActive(false);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }
    public void onResumeButton()
    {
        this.gameObject.SetActive(false);
    }
    public void onRestartButton()
    {
        OnDisable();
        SceneManager.LoadScene("Main_scene");
    }
    public void onExitButton()
    {
        OnDisable();
        SceneManager.LoadScene("Menu_scene");
    }
}
