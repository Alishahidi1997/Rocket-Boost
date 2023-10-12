using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] float thrustSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftEngineParticles;
    [SerializeField] ParticleSystem rightEngineParticles; 



    float yPos;
    float xRot;


    [SerializeField] AudioClip MainEngine;
  
    Rigidbody rb;
    AudioSource asRocket; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        asRocket = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
   
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
            StartThrusting();

        else
            StopThrusting();

    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
            RotateLeft();
        else
            leftEngineParticles.Stop();

        if (Input.GetKey(KeyCode.D))
            RotateRight();

        else
            rightEngineParticles.Stop();
    }

    private void StartThrusting()
    {
        if (!asRocket.isPlaying)
            asRocket.PlayOneShot(MainEngine);
        if (!mainEngineParticles.isPlaying)
            mainEngineParticles.Play();
        rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
    }

    private void StopThrusting()
    {
        mainEngineParticles.Stop();
        asRocket.Stop();
    }


    private void RotateLeft()
    {
        if (!leftEngineParticles.isPlaying)
            leftEngineParticles.Play();
        RocketRotation(+1);
    }

    private void RotateRight()
    {
        if (!rightEngineParticles.isPlaying)
            rightEngineParticles.Play();
        RocketRotation(-1);
    }

    private void RocketRotation(int direction)
    {
        rb.freezeRotation = true; 
        xRot = direction * Time.deltaTime * rotationSpeed;
        transform.Rotate(Vector3.forward * xRot);
        rb.freezeRotation = false;
    }
}
