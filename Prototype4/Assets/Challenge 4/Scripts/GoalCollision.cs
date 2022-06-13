using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollision : MonoBehaviour
{
    public AudioClip scoreSound;
    private AudioSource goalSoundSource;


    // Start is called before the first frame update
    void Start()
    {
        goalSoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Enemy(Clone)")
        {
            goalSoundSource.PlayOneShot(scoreSound, 1.0f);
            Debug.Log("Audio played");
        }    
    }

}
