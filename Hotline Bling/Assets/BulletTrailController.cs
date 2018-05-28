using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrailController : MonoBehaviour {

    public int movementSpeed = 50;
	// Use this for initialization
	void Start () {
        transform.Rotate(new Vector3(0, 0, 180));
        Destroy(gameObject, 1);
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
    }
}
