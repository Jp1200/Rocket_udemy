using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioS;
    [SerializeField] float rcsThrust = 65f;
    [SerializeField] float mnmThrust = 30f;
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

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Ok");
                break;
            case "Fuel":
                print("Fuel");
                break;
            default:
                print("Dead");
                break;
        }
    }

    private void Thrust()
    {
        float thrustForce = Time.deltaTime * mnmThrust;
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustForce);
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
