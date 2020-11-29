﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static bool pickPatient = false;
    public GameObject currentInterObj = null;
    public InterableObject currentInterObjScript = null;
    private HealthBar healthBar;
    public List<string> items;
    public float speed = 6f;
    public static float health = 1f;
    public Animator animator;
    public Rigidbody2D rb2d;
    public static int heart_num = 1;

    // Start is called before the first frame update
    void Start()
    {
        pickPatient = false;
        items = new List<string>();
        rb2d = GetComponent<Rigidbody2D> ();
        healthBar = GameObject.Find("BarSprite").GetComponent<HealthBar>();

        for(int j = 0; j < heart_num; j++)
        {
            Destroy(GameObject.Find("Heart" + j));
        }
        if(MainController.questionSet < 2)
            MainController.questionSet++;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(NoticeController.Active == true)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");


            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb2d.MovePosition(rb2d.transform.position + tempVect);    

            animator.SetFloat("XSpeed",h);
            animator.SetFloat("YSpeed",v);        
        }

    }
    void Update()
    {
        if(currentInterObj)
        {
            if(currentInterObjScript.objectType == "sink")
            {
                if(currentInterObjScript.timeLeft > 0)
                {
                    currentInterObjScript.timeLeft -= Time.deltaTime;
                }                  
            }
          
        }

        if (health < 0)
        {
            heart_num++;
        }
        if(Input.GetKeyDown(KeyCode.I) && currentInterObj)
        {
            if(currentInterObjScript.objectType == "door")
            {
                if (currentInterObjScript.openable)
                {
                    if (currentInterObjScript.locked)
                    {
                        currentInterObjScript.locked = false;
                        print("The door has beeen unlocked");
                        currentInterObjScript.OpenDoor();
                        Destroy(currentInterObjScript.invisibleArea);
                        InteractMessage.messageShow = false;
                    }
                }
                else
                {
                    InteractMessage.hintText.text = "The door can not be open";
                    InteractMessage.messageShow = true;
                    InteractMessage.doorUnopanable = true;
                }
                    
            }
            if(currentInterObjScript.objectType == "sink")
            {
                if(health < 1f && currentInterObjScript.timeLeft <= 0)
                {
                    health += 0.1f;
                    currentInterObjScript.timeLeft = 30;
                    InteractMessage.messageShow = false;
                }
                else if (currentInterObjScript.timeLeft > 0)
                {
                    print(currentInterObjScript.timeLeft);
                    InteractMessage.hintText.text = "You can interact with this sink 30s later";
                }
            }
            if(currentInterObjScript.objectType == "patient")
            {
                if(PatientScript.interacted == false)
                {
                    PatientScript.interacted = true;
                    pickPatient = true;
                }
                else
                {
                    PatientScript.interacted = false;
                    pickPatient = false;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collectable"))
        { 
            string itemType = collision.gameObject.GetComponent<CollectableScript>().itemType;
            print("You collect an " + itemType);
            items.Add(itemType);
            if(itemType == "mask")
            {
                MaskCountScript.maskAmount += 1;
            }
            if(itemType == "sanitizer")
            {
                if(health < 1f)
                {
                    health += 0.1f;
                }
            }
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("Virus"))
        {
            health -= .1f;

        }
        if(collision.CompareTag("Interactable"))
        {
            print(collision.name);
            currentInterObj = collision.gameObject;
            currentInterObjScript = currentInterObj.GetComponent <InterableObject> ();
            if (currentInterObjScript.objectType == "door")
            {
                if(currentInterObjScript.locked)
                {
                    InteractMessage.hintText.text = "Press i to interact";
                }
            }
            else
                InteractMessage.hintText.text = "Press i to interact";
            if (currentInterObjScript.objectType == "patient")
            {
                if(PatientScript.interacted == false)
                    InteractMessage.hintText.text = "Press i to take him";
                else
                    InteractMessage.hintText.text = "Press i to stop following";
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Interactable"))
        {
            if(collision.gameObject == currentInterObj)
            {
                currentInterObj = null;
                InteractMessage.hintText.text = "";
                InteractMessage.doorUnopanable = false;
            }
        }
    }

}