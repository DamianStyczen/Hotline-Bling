﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxBehavior : MonoBehaviour {

    
    [SerializeField] float lifeTime;
	// Use this for initialization
	void Start () {
        
        Destroy(this.gameObject, lifeTime);
	}
	
}
