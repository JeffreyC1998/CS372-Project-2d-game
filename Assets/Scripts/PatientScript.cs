using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientScript : MonoBehaviour
{
    public int direction = -1;
    public static bool interacted;
    public float speed = 9;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        interacted = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(interacted)
        {
            if(Vector2.Distance(transform.position, target.position) > 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            }
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Win"))
        {
            PatientPicked.PatientArrive = true;
            if(MaskCountScript.maskAmount == 3)
            {
                MainController.win = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Win"))
        {
            PatientPicked.PatientArrive = false;
        }
    }
}
