using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rocket : MonoBehaviour
{
    [SerializeField] float mainThrust; // SerializaField used rather than public so that value can be adjusted in the inspector but no from other scripts
    [SerializeField] float rotationalThrust;
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
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        string output = collision.gameObject.tag == "Friendly" ? "Friendly game object" : "Hazardous game object";
        print(output);
    }

    private void Rotate()
    {
        rigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, -Time.deltaTime * rotationalThrust));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationalThrust));
        }
        rigidbody.freezeRotation = false;

    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(new Vector3(0, mainThrust * Time.deltaTime, 0));
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
