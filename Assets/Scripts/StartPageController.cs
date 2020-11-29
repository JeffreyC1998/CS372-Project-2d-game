using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPageController : MonoBehaviour
{
    public static string Name;
    public GameObject inputField;

    // Start is called before the first frame update
    public void StoreName()
    {
        Name = inputField.GetComponent<Text>().text;
    }
    public void StartGame()
    {
        if(inputField.GetComponent<Text>().text != "" && inputField.GetComponent<Text>().text.Length <= 9)
        {
            MaskCountScript.maskAmount = 0;
            PatientScript.interacted = false;
            MainController.win = false;
            PlayerControl.health = 1f;
            NoticeController.Active = false;
            PlayerControl.heart_num = 1;
            SceneManager.LoadScene("MainScene");
        }
        else if(inputField.GetComponent<Text>().text == "")
        {
            ErrorMessageDisplay.Errmsg = "Please enter a name";
        }
        else if(inputField.GetComponent<Text>().text.Length > 9)
        {
            ErrorMessageDisplay.Errmsg = "Please make sure your name is no longer that 9 characters";
        }

    }
    // Update is called once per frame
}
