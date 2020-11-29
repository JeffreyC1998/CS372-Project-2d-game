using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeController : MonoBehaviour
{
    public GameObject player;
    public static bool Active = false;
    // Start is called before the first frame update
    void Start()
    {
        if(Active == true)
        {
            Destroy(GameObject.Find("Notice"));
        }
    }
    public void GameStart()
    {
        Active = true;
        Destroy(GameObject.Find("Notice"));
    }
}
