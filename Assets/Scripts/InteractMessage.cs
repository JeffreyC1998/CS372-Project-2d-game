using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractMessage : MonoBehaviour
{
    public static bool messageShow = false;
    public static bool doorUnopanable = false;
    public Text hintText;
    // Start is called before the first frame update
    void Start()
    {
        hintText = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(messageShow == false)
        {
            hintText.text = "";
        }
        else
        {
            if(doorUnopanable == true)
            {
                hintText.text = "The door can not be open";
            }
            else
                hintText.text = "Press i to interact";
        }
            
    }
}
