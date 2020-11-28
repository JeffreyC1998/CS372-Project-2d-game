using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientPicked : MonoBehaviour
{
    Text mission2;
    // Start is called before the first frame update
    void Start()
    {
        mission2 = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControl.pickPatient == true)
        {
            mission2.text = "Take this patient to the room in the bottom";
        }
    }
}
