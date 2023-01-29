using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Collectable
{
    public float fishMass = 1.1f;
    public float size;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            // in functia asta daca nu poate sa-l manance dam destroy player si game over
            coll.SendMessage("EatFish", size);
            Destroy(gameObject);
        }
    }
}
