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
    private const float RunningSpeed = 2f;
    private const float NormalSpeed = 1.4f;
    private float _movementSpeed = NormalSpeed;
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
        // if (playerMass >= 60)
        // {
        //     SceneManager.LoadScene("WinGameScene");   
        // }

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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Math.Abs(currentScale.x) >= 0.06401)
            {
                ScoreManager.instance.SubtractMass();
                _movementSpeed = RunningSpeed;
                playerMass -= 0.025f;
                transform.localScale = new Vector3(currentScale.x * 0.9988f, currentScale.y * 0.9988f, currentScale.z);
            }
            else
                _movementSpeed = NormalSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _movementSpeed = NormalSpeed;
        }
        
        // moving in y axis
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(_movementSpeed*moveDelta.y * Time.deltaTime), LayerMask.GetMask( "Blocking"));
        if(!hit.collider)
        {
            transform.Translate(0, _movementSpeed* moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(_movementSpeed*moveDelta.x * Time.deltaTime), LayerMask.GetMask( "Blocking"));
        if (!hit.collider)
        {
            transform.Translate(_movementSpeed*moveDelta.x * Time.deltaTime, 0, 0);
        }
    }

    protected void EatCarrot(float carrotMass)
    {
        Vector3 currentScale = transform.localScale;
        ScoreManager.instance.AddMass(10);
        playerMass = playerMass + 1.0f;
        transform.localScale = new Vector3(Math.Abs(currentScale.x * 1.05f), currentScale.y * 1.05f, currentScale.z);
    }
    
    protected void EatFish(float fishMass)
    {
        Vector3 currentScale = transform.localScale;

        Debug.Log("player mass: " + playerMass + ", NPC mass: " + fishMass);
          
        if (fishMass < playerMass)
        {
            ScoreManager.instance.AddMass(10);
            playerMass = playerMass + 1.0f;
            transform.localScale = new Vector3(Math.Abs(currentScale.x * 1.05f), currentScale.y * 1.05f, currentScale.z);
        }
        else
        {
            Destroy(gameObject);
            // SceneManager.LoadScene("GameOverScene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
