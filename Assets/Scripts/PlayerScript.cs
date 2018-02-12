using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerScript : NetworkBehaviour {

    public float maxForce = 10f;
    public float slowRate = 5f;
    public float speedRate = 5f;
    public GameObject sprite;
    public float force = 0f;
    public Rigidbody2D rb2D;
    void Start()
    {
        if (sprite == null )
        {
            sprite = gameObject;
        }
        rb2D = sprite.GetComponent<Rigidbody2D>();
        rb2D.drag = slowRate;
    }

    // Update is called once per frame
    void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        //// Touche screen
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            Ray touchRay = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit[] hits = Physics.RaycastAll(touchRay);
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.gameObject == gameObject)
                {
                    Vector2 thatPosition = touch.position;
                    SpeedUp(thatPosition);
                }
            }
        }

        //// Mouse Input
        if (Input.GetMouseButton(0))
        {
            Ray touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.gameObject == gameObject)
                {
                    Vector2 thatPosition = Input.mousePosition;
                    SpeedUp(thatPosition);
                }
            }
        }

        if (force > 0)
        {
            force -= (slowRate * Time.deltaTime);
        }
        sprite.GetComponent<BumpScript>().bumpForce = rb2D.velocity.magnitude * 10;
        
    }

/*
    void OnMouseOver()
    {
        if (isLocalPlayer)
        {
            Debug.Log("player " + this);
            if (Input.GetMouseButton(0))
            {
                Vector2 thatPosition = Input.mousePosition;
                SpeedUp(thatPosition);
            }
        }
    }
    */
    private void SpeedUp(Vector2 thatPosition)
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(thatPosition);
        Vector2 v = p - transform.position;
        if (force < maxForce)
        {
            force += (speedRate * Time.deltaTime);
        }
        rb2D.AddForce(v * force);
    }
    
}
