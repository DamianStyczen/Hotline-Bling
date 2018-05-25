using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DropWeapon Effect", menuName = "Effects/New DropWeapon Effect")]
public class DropWeapon : Effect {

    public GameObject PickUpPrefab;
    public List<Weapon> weapons = new List<Weapon>();
	public override void Execute(GameObject caller)
    {
        Instantiate(PickUpPrefab, caller.transform.position, Quaternion.identity);
        PickUpPrefab.GetComponent<PickUpController>().droppedWeapon = weapons[UnityEngine.Random.Range(0, weapons.Count)];
    }
}
