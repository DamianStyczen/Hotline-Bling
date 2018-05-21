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

    private void performAttack()
    {
        GameObject.Instantiate(meleeHitbox, this.transform);        
    }

    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            if(weapon == null)
            {
                meleeAttack();
            }
            else
            {
                weaponAttack();
            }
        }

        
    }

    private void weaponAttack()
    {
        if(timer > weapon.fireCooldown)
        {
            shoot();
            weaponAmmo -= 1;
            if(weaponAmmo == 0)
            {
                Debug.Log("Weapon is empty.");
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
            performAttack();
            timer = 0;
        }
               
        
        
        
    }

    public void pickUpWeapon(Weapon pickUp)
    {
        
        weapon = pickUp;
        weaponAmmo = weapon.ammo;
        weaponModel.SetActive(true);
    }

    private void shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(weaponModel.transform.position, -transform.right);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy hit");
                hit.collider.gameObject.GetComponent<enemyBehavior>().getDamage(weapon.damage);
            }
        }            
        
        else
        {
            Debug.Log("You missed");
        }



    }
}
