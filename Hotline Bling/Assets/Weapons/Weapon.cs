using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/New Weapon")]
public class Weapon : ScriptableObject {

    public GameObject bulletTrail;
    public float damage = 0;
    public int ammo = 0;
    public float fireCooldown = 0.1f;   

    public virtual void Shoot(GameObject startingObject)
    {
        Debug.Log(this.name +" fired");
        RaycastHit2D hit = Physics2D.Raycast(startingObject.transform.position, -startingObject.transform.right);
        Quaternion rot = startingObject.transform.rotation;
        GameObject trail = Instantiate(bulletTrail, startingObject.transform.position, rot);
        trail.transform.Rotate(trail.transform.right);
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
