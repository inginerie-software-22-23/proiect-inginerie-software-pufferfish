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
    private const float RunningSpeed = 2f;
    private const float NormalSpeed = 1.4f;
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
    }
    
    private void FixedUpdate()
    {
         if (playerMass >= 60)
         {
            SceneManager.LoadScene("WinGameScene");   
         }

        Vector3 currentScale = transform.localScale;
        playerx = currentScale.x;
        playery = currentScale.y;
        playerz = currentScale.z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Math.Abs(currentScale.x) >= 0.06401 && playerMass > 1.05f)
            {
                // ScoreManager.instance.SubtractMass();
                _movementSpeed = RunningSpeed;
                playerMass -= 0.025f;
                // transform.localScale = new Vector3(currentScale.x * 0.9988f, currentScale.y * 0.9988f, currentScale.z);
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
        eatCarrot.Play();

        playerMass = playerMass + 1.0f;
        // transform.localScale = new Vector3(Math.Abs(currentScale.x * 1.05f), currentScale.y * 1.05f, currentScale.z);
    }
    
    protected void EatFish(float fishMass)
    {
        Vector3 currentScale = transform.localScale;

        Debug.Log("player mass: " + playerMass + ", NPC mass: " + fishMass);
          
        if (fishMass < playerMass)
        {
            eatFish.Play();
            playerMass = playerMass + 1.0f;
            // transform.localScale = new Vector3(Math.Abs(currentScale.x * 1.05f), currentScale.y * 1.05f, currentScale.z);
        }
        else
        {
            Destroy(gameObject);
             SceneManager.LoadScene("GameOverScene");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
