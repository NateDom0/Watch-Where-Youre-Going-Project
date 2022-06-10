using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody playerRb; //variable to get reference to rigidbody
    private GameObject focalPoint; 
    private float powerupStrength = 15.0f;

    public float speed = 5.0f; 
    public bool hasPowerup = false; // initially set to false(off)
    public GameObject powerupIndicator;

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

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); // set powerup indicator to player position
    }


    // 'Trigger' is useful when trying to understand triggers between colliders
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;  // to test if player picked up powerup

            powerupIndicator.gameObject.SetActive(true); // initially set inactive in inspector window, so set true once player has powerup

            Destroy(other.gameObject);

            StartCoroutine(PowerupCountdownRoutine()); // starts the thread(loop) outside of update method and call poweruproutine
        }
    }

    // known as an interface. 
    IEnumerator PowerupCountdownRoutine()
    {   
        // yield enables us to run the timer. 
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false); // turns indicator off(back to inactive)
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
