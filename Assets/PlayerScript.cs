using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float maxForce = 10f;
    public float slowRate = 5f;
    public float speedRate = 5f;
    public GameObject sprite;
    public float force = 0f;
    public Rigidbody2D rb2D;
    void Start()
    {
        rb2D = sprite.GetComponent<Rigidbody2D>();
        rb2D.drag = slowRate;
    }

    // Update is called once per frame
    void Update () {

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

        if (force > 0)
        {
            force -= (slowRate * Time.deltaTime);
        }
        sprite.GetComponent<BumpScript>().bumpForce = rb2D.velocity.magnitude * 10;
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 thatPosition = Input.mousePosition;
            SpeedUp(thatPosition);
        }
    }

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
