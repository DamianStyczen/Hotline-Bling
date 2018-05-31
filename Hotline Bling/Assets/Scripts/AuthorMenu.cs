using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorMenu : MonoBehaviour {

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject AuthorMenuObject;

    public void onBackButton()
    {
            MainMenu.SetActive(true);
            AuthorMenuObject.SetActive(false);
        
    }
}
