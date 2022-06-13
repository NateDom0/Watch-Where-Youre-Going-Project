using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed; // changed from 2.0f to 0f
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    //public AudioClip scoreSound;
    //private AudioSource goalSoundSource;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal"); // reference the Player Goal object
        speed = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().enemySpeed; //reference enemy speed in Spawn manager
        //goalSoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            //goalSoundSource.PlayOneShot(scoreSound, 1.0f);
            Destroy(gameObject);
            
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
