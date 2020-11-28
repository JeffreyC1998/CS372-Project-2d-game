using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public static int questionSet = 0;
    public static bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControl.health <= 0 && PlayerControl.heart_num <= 3)
        {
            SceneManager.LoadScene("Persistent" + questionSet);
        }
        else if(PlayerControl.heart_num > 3)
        {
            SceneManager.LoadScene("GameOver");
        }
        if(win == true)
        {
            SceneManager.LoadScene("WinPage");
        }
    }
}
