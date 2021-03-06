﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/New Shotgun")]
public class Shotgun : Weapon {


    public int pallets = 3;
    public float spread = 10;


    public override void Shoot(GameObject startingObject)
    {
        Debug.Log("Shotgun fired");
        RaycastHit2D hit = Physics2D.Raycast(startingObject.transform.position, -new Vector3(startingObject.transform.right.x - spread, startingObject.transform.right.y - spread, startingObject.transform.right.y));
        Debug.DrawRay(startingObject.transform.position, -new Vector3(startingObject.transform.right.x - spread, startingObject.transform.right.y - spread, startingObject.transform.right.y));


        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy hit");
                hit.collider.gameObject.GetComponent<EnemyBehavior>().getDamage(damage);
            }
        }
        
    }
}
