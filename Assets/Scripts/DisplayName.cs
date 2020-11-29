using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour
{
    public string Username;
    public Text display;
    // Start is called before the first frame update
    void Start()
    {
        Username = StartPageController.Name;
        display = GetComponent<Text> ();
        display.text += Username;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
