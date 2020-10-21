using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioS;
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
            if (!audioS.isPlaying) { audioS.Play(); }

            rigidBody.AddRelativeForce(Vector3.up);
        }
        else { audioS.Stop(); }
    }
    private void Rotate()
    {
        rigidBody.freezeRotation = true; // Take manual rotation
        if (Input.GetKey(KeyCode.A))
        {
            //rotation = rigidBody * Time.deltaTime;
            transform.Rotate(Vector3.forward);
        }

        else if (Input.GetKey(KeyCode.D))
        { transform.Rotate(-Vector3.forward); }
        rigidBody.freezeRotation = false;
    }

   
}
