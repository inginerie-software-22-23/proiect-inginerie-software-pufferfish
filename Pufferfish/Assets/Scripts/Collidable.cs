using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    protected BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        //Collision work
        //cauta ceva in coliziune sub si deasupra
        boxCollider.OverlapCollider(filter, hits);

        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i] == null)
            {
                continue;
            }

            //Debug.Log(hits[i].name);
            OnCollide(hits[i]);
            

            //the array isn't cleared 
            hits[i] = null;
        }
    }
    //folosim in mostenire

    protected virtual void OnCollide(Collider2D coll)
    {
        //Debug.Log(coll.name);
    }
}
