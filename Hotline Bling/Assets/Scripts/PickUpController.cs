﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    [SerializeField] List<Weapon> items = new List<Weapon>();

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
                collision.gameObject.GetComponent<AttackController>().pickUpWeapon(items[0]);
                GameObject.Destroy(gameObject);
            }
        }
    }
}
