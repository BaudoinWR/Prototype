using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BumpableScript : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BumpScript>() != null)
        {
            Vector2 v = new Vector2(transform.position.x, transform.position.y)  - collision.contacts[0].point;
            
            float force = collision.gameObject.GetComponent<BumpScript>().bumpForce;
            GetComponent<Rigidbody2D>().AddForce(v * force);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BumpScript>() != null)
        {
            Vector2 v = new Vector2(transform.position.x, transform.position.y) - collision.contacts[0].point;

            float force = collision.gameObject.GetComponent<BumpScript>().bumpForce;
            GetComponent<Rigidbody2D>().AddForce(v * force);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
