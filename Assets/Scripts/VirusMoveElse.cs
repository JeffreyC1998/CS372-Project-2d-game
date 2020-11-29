using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMoveElse : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb2d;
    public float speed = 15f;
    public int Xdirection = 1;
    public int Ydirection = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb2d.transform.position.y < 69 && rb2d.transform.position.y > 40 && rb2d.transform.position.x < -33)
        {
            Vector3 move = new Vector3(Xdirection, 0, 0);
            move = move.normalized * speed * Time.deltaTime;
            rb2d.MovePosition(rb2d.transform.position + move);
            if(rb2d.transform.position.x < -52)
            {
                Xdirection = 1;
            }
            else if(rb2d.transform.position.x > -36)
            {
                Xdirection = -1;
            }
        }
        else if(rb2d.transform.position.y < 69 && rb2d.transform.position.y > 40 && rb2d.transform.position.x > -10)
        {
            Vector3 move = new Vector3(Xdirection, 0, 0);
            move = move.normalized * speed * Time.deltaTime;
            rb2d.MovePosition(rb2d.transform.position + move);
            if(rb2d.transform.position.x < -3)
            {
                Xdirection = 1;
            }
            else if(rb2d.transform.position.x > 14)
            {
                Xdirection = -1;
            }
        }
        else if(rb2d.transform.position.x < -4 && rb2d.transform.position.x > -35 && rb2d.transform.position.y > 70)
        {
            if(rb2d.transform.position.y < 70.3)
            {
                Ydirection = 1;
            }
            else if(rb2d.transform.position.y > 79.2)
            {
                Ydirection = -1;
            }
            Vector3 move = new Vector3(0, Ydirection, 0);
            move = move.normalized * speed * Time.deltaTime;
            rb2d.MovePosition(rb2d.transform.position + move);
        }
        else if(rb2d.transform.position.x < -4 && rb2d.transform.position.x > -35 && rb2d.transform.position.y < 40)
        {
            if(rb2d.transform.position.y < 31)
            {
                Ydirection = 1;
            }
            else if(rb2d.transform.position.y > 39.6)
            {
                Ydirection = -1;
            }
            Vector3 move = new Vector3(0, Ydirection, 0);
            move = move.normalized * speed * Time.deltaTime;
            rb2d.MovePosition(rb2d.transform.position + move);
        }
    }
}
