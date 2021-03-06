﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    public Weapon droppedWeapon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.tag == "Player")
            {
                Debug.Log("Weapon PICKED UP");
                collision.gameObject.GetComponent<AttackController>().PickUpWeapon(droppedWeapon);
                GameObject.Destroy(gameObject);
            }
        }
    }
}
