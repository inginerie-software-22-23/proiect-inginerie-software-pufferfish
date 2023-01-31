using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCarrot : MonoBehaviour
{
    private readonly int _direction = -1;
    private Vector3 _movement;

    void Update()
    {
        Vector3 currentPosition = transform.position;
        _movement = new Vector3(0, 0.75f * _direction, 0);

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

