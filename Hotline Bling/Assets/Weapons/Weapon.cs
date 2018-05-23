using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/New Weapon")]
public class Weapon : ScriptableObject {

    public float damage = 0;
    public int ammo = 0;
    public float fireCooldown = 0.1f;

    public Sprite sprite;

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
