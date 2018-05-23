using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {

    public void Shoot(GameObject startingObject)
    {
        RaycastHit2D hit = Physics2D.Raycast(startingObject.transform.position, -startingObject.transform.right);
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
