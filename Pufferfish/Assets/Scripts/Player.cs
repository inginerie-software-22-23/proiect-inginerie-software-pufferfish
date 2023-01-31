using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : Collidable
{
    //INHERITED
    //movement
    private const float RunningSpeed = 1.75f;
    private const float NormalSpeed = 1.0f;
    private float _movementSpeed = NormalSpeed;
    private Vector3 moveDelta;
    //scaling and sprinting
    private float playerx, playerz, playery;
    private RaycastHit2D hit;
    public float playerMass = 1f;
    private float baseX, baseY, baseZ;
    //sounds
    public AudioSource eatCarrot;
    public AudioSource eatFish;

    public bool isGameOver = false;

    protected override void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        Vector3 currentScale = transform.localScale;
        baseX = currentScale.x;
        baseY = currentScale.y;
        baseZ = currentScale.z;
    }

    protected override void Update()
    {
        base.Update();
        
        if (playerMass >= 45)
        {
            SceneManager.LoadScene("WinGameScene");   
        }
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDelta = new Vector3(x, y, 0);

        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(baseX * (float)Math.Pow(1.05, playerMass - 1), 
                baseY * (float)Math.Pow(1.05, playerMass - 1), baseZ);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-baseX * (float)Math.Pow(1.05, playerMass - 1), 
                baseY * (float)Math.Pow(1.05, playerMass - 1), baseZ);
        }
        
        Vector3 currentScale = transform.localScale;
        playerx = currentScale.x;
        playery = currentScale.y;
        playerz = currentScale.z;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Math.Abs(currentScale.x) >= 0.06401 && playerMass > 1.05f)
            {
                _movementSpeed = RunningSpeed;
                playerMass -= 0.0025f;
            }
            else
            {
                _movementSpeed = NormalSpeed;
            }
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
        eatCarrot.Play();
        playerMass += 1.0f;
    }
    
    protected void EatFish(float fishMass)
    {
        if (fishMass < playerMass)
        {
            eatFish.Play();
            playerMass += 1.0f;
        }
        else
        {
            isGameOver = true;
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
