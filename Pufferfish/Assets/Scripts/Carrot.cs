using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Carrot : Collectable
{
    public Sprite eatenCarrot;
    public float massCarrot = 1.05f;
    protected override void OnCollect(Collider2D coll)
    {
        if (collected == false)
        {
            collected = true;



            coll.SendMessage("ReceiveMass", massCarrot);

            Debug.Log("Grant " + massCarrot + " mass");
            Destroy(gameObject);
        }
    }
}
