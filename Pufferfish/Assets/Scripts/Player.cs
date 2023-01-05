using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    //INHERITED
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private float playerx, playerz, playery;
    //private RaycastHit2D hit;



    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // reset MoveDelta
        moveDelta = new Vector3(x, y, 0);
        Vector3 currentScale = transform.localScale;
        playerx = currentScale.x;
        playery = currentScale.y;
        playerz = currentScale.z;

        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(Math.Abs(playerx),playery,playerz);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-Math.Abs(playerx), playery, playerz);
        }
        transform.Translate(moveDelta * Time.deltaTime);    

        //Debug.Log(x);
        //Debug.Log(y);
    }
}
