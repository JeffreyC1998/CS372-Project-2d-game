using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;
        
        temp.x += offset;
        temp.y += offset;

        transform.position = temp;
    }
}
