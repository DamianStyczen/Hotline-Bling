using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponController : MonoBehaviour {

    [SerializeField] GameObject Ammo;
    [SerializeField] GameObject Weapon;
    int maxAmmo;

    // Use this for initialization
    void Start () {
        Weapon.GetComponent<Text>().text = "MELEE";
        Ammo.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeWeapon(string name)
    {
        Weapon.GetComponent<Text>().text = name.ToUpper();
        Ammo.SetActive(false);
    }

    public void changeWeapon(string name, int ammo)
    {
        Weapon.GetComponent<Text>().text = name.ToUpper();
        Ammo.SetActive(true);
        maxAmmo = ammo;
        Ammo.GetComponent<Text>().text = ammo + "/" + ammo;
    }

    public void ammoChange(int currentAmmo)
    {
        Ammo.GetComponent<Text>().text = currentAmmo + "/" + maxAmmo;
    }
}
