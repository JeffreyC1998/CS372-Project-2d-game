using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private Transform playerTransform;
    public float offset;
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        bar = transform.Find("Bar");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = PlayerControl.health;
        transform.localScale = localScale;
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x + 13;
        temp.y = playerTransform.position.y + 6;
        
        temp.x += offset;
        temp.y += offset;

        transform.position = temp;
    }

}
