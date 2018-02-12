using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MaxSpeedScript : NetworkBehaviour {

    public float topSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D.velocity.magnitude > topSpeed)
        {
            rigidbody2D.velocity *= topSpeed / rigidbody2D.velocity.magnitude;
        }
	}
}
