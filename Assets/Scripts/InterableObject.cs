using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterableObject : MonoBehaviour
{
    public string objectType;
    public bool openable;
    public bool locked;
    public GameObject invisibleArea;
    public int timeLeft = 0;
    public Animator animator;
    // Start is called before the first frame update
    void update()
    {
        
    }
    public void OpenDoor()
    {
        animator.SetBool("open", true);
        animator.SetBool("close", false);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void CloseDoor()
    {
        animator.SetBool("close", true);
        animator.SetBool("open", false);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
