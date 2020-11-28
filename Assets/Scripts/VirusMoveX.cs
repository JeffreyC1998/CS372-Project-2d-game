using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMoveX : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 15f;
    public int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb2d.transform.position.x < -52)
        {
            direction = 1;
        }
        else if(rb2d.transform.position.x > 13)
        {
            direction = -1;
        }
        Vector3 move = new Vector3(direction, 0, 0);
        move = move.normalized * speed * Time.deltaTime;
        rb2d.MovePosition(rb2d.transform.position + move);
    }
}
