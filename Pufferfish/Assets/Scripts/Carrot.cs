using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Carrot : Collectable
{
    public Sprite eatenCarrot;
    public float carrotMass = 1f;
    
    protected override void OnCollect(Collider2D coll)
    {
        if (collected == false)
        {
            collected = true;
            coll.SendMessage("EatCarrot", carrotMass);

            Debug.Log("Grant " + carrotMass + " mass");
            Destroy(gameObject);
        }
    }
}
