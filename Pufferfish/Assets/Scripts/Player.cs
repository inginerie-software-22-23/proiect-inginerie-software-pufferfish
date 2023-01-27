using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]

public class Player : Collidable
{
    //INHERITED
    //private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private float playerx, playerz, playery;
    private RaycastHit2D hit;
    public float playerMass = 1.06f;

    protected override void Start()
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

        //moving in y axis
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask( "Blocking"));
        if(hit.collider == null)
        {

            //Debug.Log("not border");
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        else
        {

            //Debug.Log("border");
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask( "Blocking"));
        if (hit.collider == null)
        {

            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        //Debug.Log(x);
    }

    protected void ReceiveMass(float size)
    {
        Vector3 currentScale = transform.localScale;

        //if (size >= 60)
          //  SceneManager.LoadScene("WinGameScene");

        if (size < playerMass)
        {
            playerMass = playerMass + 1.05f;
            transform.localScale = new Vector3(Math.Abs(currentScale.x * 1.05f), currentScale.y * 1.05f, currentScale.z);
        }
        //else
        //{
            
         //   Destroy(gameObject);
          //  SceneManager.LoadScene("GameOverScene");
           // //game over
       // }

    }

}
