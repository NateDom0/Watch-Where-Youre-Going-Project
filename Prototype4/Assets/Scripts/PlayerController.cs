using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody playerRb; //variable to get reference to rigidbody

    private GameObject focalPoint; 

    public float speed = 1.0f; 



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
}
