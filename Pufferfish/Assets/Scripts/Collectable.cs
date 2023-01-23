using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    //logic 
    [SerializeField]
    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            // Debug.Log(this.gameObject.name);
            Debug.Log("Carrot");
            OnCollect(coll);
        }
    }

    protected virtual void OnCollect(Collider2D coll)
    {
        collected = true;
    }
}
