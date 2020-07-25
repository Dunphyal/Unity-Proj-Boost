using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rocket : MonoBehaviour
{
    public int Thrust;
    Rigidbody rigidbody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            audioSource.Stop();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(new Vector3(0, Thrust, 0));
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 1));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -1));
        }
    }
}
