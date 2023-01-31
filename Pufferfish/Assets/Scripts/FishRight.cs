using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRight : MonoBehaviour
{
    private int direction = -1;
    private Vector3 movement;
    public float speed = 1.0f;

    void Update()
    {
        Vector3 currentPosition = transform.position;
        movement = new Vector3(direction * speed, 0, 0);
        if (currentPosition.x >= -10)
            transform.position = transform.position + movement * Time.deltaTime;
        else
            Destroy(gameObject);
    }

    /*  private void OnCollisionStay(Collision coll)
      {
          if (coll.gameObject.CompareTag("Box"))
              direction = direction * -1;
      }*/
}
