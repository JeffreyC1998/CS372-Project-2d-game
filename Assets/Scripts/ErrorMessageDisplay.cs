using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessageDisplay : MonoBehaviour
{
    public static string Errmsg;
    public Text ErrorDisplay;
    // Start is called before the first frame update
    void Start()
    {
        ErrorDisplay = GetComponent<Text> ();
        StartCoroutine(ExecuteAfterTime());
    }
    void Update()
    {
        ErrorDisplay.text = Errmsg;
    }
    IEnumerator ExecuteAfterTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            if(Errmsg != "")
            {
                Errmsg = "";
            }            
        }
        //yield on a new YieldInstruction that waits for 3 seconds.

    }

}
