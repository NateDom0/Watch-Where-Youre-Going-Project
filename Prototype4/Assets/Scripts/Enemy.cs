using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy should be able to follow 'Player'

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;

    // Need reference to our Player
    private GameObject player;

    public float speed = 1.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Use Vector3 because we're taking in two different positions: player and current transform(enemy)
        // normalize the magnitude of this vector
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce( lookDirection * speed); 

    }
}
