using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawner : MonoBehaviour
{
    public GameObject carrot;
    private float _randX;
    private Vector2 _whereToSpawn;
    public float spawnRate = 7f;
    private float _nextSpawn = 0.5f;
    private Player _player;

    public void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextSpawn && !_player.stage2)
        {
            _nextSpawn = Time.time + spawnRate;
            _randX = Random.Range(-8.38f, 8.58f);
            _whereToSpawn = new Vector2(_randX, transform.position.y);
            
            Instantiate(carrot, _whereToSpawn, Quaternion.identity);
        }
    }
}
