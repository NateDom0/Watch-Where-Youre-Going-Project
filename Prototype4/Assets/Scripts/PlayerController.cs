using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody playerRb; //variable to get reference to rigidbody

    private GameObject focalPoint; 

    public float speed = 1.0f; 

    public bool hasPowerup = false; // initially set to false(off)

    private float powerupStrength = 15.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); //get reference to player's rigidbody
        focalPoint = GameObject.Find("Focal Point"); //reference to focal point object
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        
        //playerRb.AddForce(Vector3.forward * forwardInput * speed);
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
    }

    // 'Trigger' is useful when trying to understand triggers between colliders
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;  // to test if player picked up powerup
            Destroy(other.gameObject);
        }
    }

    // Use 'Collision' for physics
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>(); // get rigidbody of enemy
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position; // get direction to send enemy away from player

            // apply force to enemy in direction away from player * powerupstrength, and force is applied instantly
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            // Use concatenation to debug in console
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }

}
