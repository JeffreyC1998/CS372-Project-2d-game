using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSet : MonoBehaviour
{
    public bool openable;
    public bool locked;
    public GameObject itemNeeded;
    public Animator animator;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {

    }
    public void OpenDoor()
    {
        animator.SetBool("open", true);
        animator.SetBool("close", false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void CloseDoor()
    {
        animator.SetBool("close", true);
        animator.SetBool("open", false);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
