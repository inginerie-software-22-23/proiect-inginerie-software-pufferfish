using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingCarrot : MonoBehaviour

{
    private int direction = -1;
    private Vector3 movement;

    void Update()
    {
        Vector3 currentPosition = transform.position;
        movement = new Vector3(0, direction, 0);
        if (currentPosition.y >= -6)
            transform.position = transform.position + movement * Time.deltaTime;
        else
            Destroy(gameObject);
    }

}

