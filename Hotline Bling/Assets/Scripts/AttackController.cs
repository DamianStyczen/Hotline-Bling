using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

    [Header("Melee Attack")]
    [SerializeField] float meleeCooldown = 0.6f;
    [SerializeField] GameObject meleeHitbox;

    [Header("Weapon Attack")]
    [SerializeField] GameObject weaponModel;
    [SerializeField] Weapon weapon;
    [SerializeField] int weaponAmmo;
    
    float timer;
    


    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        if(weapon == null)
        {
            weaponModel.SetActive(false);
        }
	}

    private void PerformAttack()
    {
        GameObject.Instantiate(meleeHitbox, this.transform);        
    }

    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && (Time.timeScale > 0))
        {
            if(weapon == null)
            {
                meleeAttack();
            }
            else
            {
                WeaponAttack();
            }
        }

        
    }

    private void WeaponAttack()
    {
        if(timer > weapon.fireCooldown)
        {
            weapon.Shoot(weaponModel);
            weaponAmmo -= 1;
            GameObject.Find("UIWeaponController").GetComponent<UIWeaponController>().ammoChange(weaponAmmo);

            if (weaponAmmo == 0)
            {

                GameObject.Find("TextController").GetComponent<TextController>().generateText("empty", 1);
                GameObject.Find("UIWeaponController").GetComponent<UIWeaponController>().changeWeapon("Melee");
                weapon = null;
                weaponModel.SetActive(false);
            }
            timer = 0;
        }
        
    }

    private void meleeAttack()
    {
        if (timer > meleeCooldown)
        {
            PerformAttack();
            timer = 0;
        }
               
        
        
        
    }

    public void PickUpWeapon(Weapon pickUp)
    {
        weapon = pickUp;
        weaponAmmo = weapon.ammo;
        weaponModel.SetActive(true);
        GameObject.Find("TextController").GetComponent<TextController>().generateText("Picked up", weapon.name, 40, 40);
        GameObject.Find("UIWeaponController").GetComponent<UIWeaponController>().changeWeapon(weapon.name, weapon.ammo);
    }

    
}
