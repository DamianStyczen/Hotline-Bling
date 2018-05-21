using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "New Weapon")]
public class Weapon : ScriptableObject {

    public float damage = 0;
    public int ammo = 0;
    public float fireCooldown = 0.1f;

    public Sprite sprite;
}
