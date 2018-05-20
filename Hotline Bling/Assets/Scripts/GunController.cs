using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {            
            shoot();
        }

    }

    private void shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right);
        Debug.DrawRay(transform.position, -transform.right, Color.red);
        if (hit.collider.gameObject.tag == "Enemy")
        {
            hit.collider.gameObject.GetComponent<enemyBehavior>().die();
        }
        Debug.DrawRay(transform.position, -transform.right, Color.red);

    }

    
}

    
