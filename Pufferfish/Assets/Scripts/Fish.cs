using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Collectable
{
    public float fishMass;
    private Player _player;
    public SpriteRenderer spriteRenderer;
    public Sprite fishEaten;
    public bool isFishEaten;

    protected override void Start()
    {
        base.Start();
        isFishEaten = false;
        
        var player = GameObject.Find("Player");
        if (player)
        {
            _player = player.GetComponent<Player>();
        }
    }

    protected override void Update()
    {
        base.Update();

        if (_player.playerMass > fishMass)
        {
            var sprite = GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Carrot";
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player" && !CompareTag("Friendly") && isFishEaten == false)
        {
            // in functia asta daca nu poate sa-l manance dam destroy player si game over
            coll.SendMessage("EatFish", fishMass);

            if (!_player.isGameOver)
            {
                isFishEaten = true;
                spriteRenderer.sprite = fishEaten;
            }
        }
    }
}
