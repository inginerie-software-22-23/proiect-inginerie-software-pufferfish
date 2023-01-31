using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLeft : MonoBehaviour
{
    private int direction = 1;
    private Vector3 movement;
    private Fish fish;

    void Start()
    {

        fish = GetComponent<Fish>();
    }
    void Update()
    {
        if (!fish.isFishEaten)
        {

            Vector3 currentPosition = transform.position;
            movement = new Vector3(direction, 0, 0);
            if (currentPosition.x <= 10)
                transform.position = transform.position + movement * Time.deltaTime;
            else
                Destroy(gameObject);
        }
        else
        {
            direction = -1;
            Vector3 currentPosition = transform.position;
            movement = new Vector3(0, direction, 0);
            if (currentPosition.y >= -6)
                transform.position = transform.position + movement * Time.deltaTime;
            else
                Destroy(gameObject);
        }
    }

    
}