using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRight : MonoBehaviour
{
    private int _direction = -1;
    private Vector3 _movement;
    private Fish _fish;
    public float speed = 1.0f;

    void Start()
    {
        _fish = GetComponent<Fish>();
    }
    
    void Update()
    {
        if (!_fish.isFishEaten)
        {
            Vector3 currentPosition = transform.position;
            _movement = new Vector3(_direction*speed, 0, 0);

            if (currentPosition.x >= -10)
            {
                transform.position += _movement * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            _direction = -1;
            Vector3 currentPosition = transform.position;
            _movement = new Vector3(0, _direction, 0);
            
            if (currentPosition.y >= -6)
            {
                transform.position += _movement * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
