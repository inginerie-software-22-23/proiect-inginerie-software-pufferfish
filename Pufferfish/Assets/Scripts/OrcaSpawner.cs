using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaSpawner : MonoBehaviour
{
    public GameObject fishL;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 7f;
    float nextSpawn = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(-4.77f, 4.22f);
            whereToSpawn = new Vector2(transform.position.x, randY);
            Instantiate(fishL, whereToSpawn, Quaternion.identity);
        }
    }
}
