using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioS;
    [SerializeField] float rcsThrust = 65f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
         Thrust();
         Rotate();
    }
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if (!audioS.isPlaying) {
                audioS.Play();
                print(audioS);
            }

            
        }
        else { audioS.Stop(); }
    }
    private void Rotate()
    {
        
        float rotationSpeed = rcsThrust * Time.deltaTime;
        rigidBody.freezeRotation = true; // Take manual rotation
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(Vector3.forward * rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.D))
        { transform.Rotate(-Vector3.forward * rotationSpeed); }

        rigidBody.freezeRotation = false;
    }

   
}
