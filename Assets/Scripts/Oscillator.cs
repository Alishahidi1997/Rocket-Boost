using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementSpeed;
    [SerializeField] [Range(0,1)] float movementFactor ;
    [SerializeField] float period = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }
            float cycle = Time.time / period; 
        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(tau * cycle);
        movementFactor = (rawSineWave + 1f) / 2f;
        Vector3 movementOffset = movementFactor * movementSpeed;
        transform.position =  ( movementOffset + startingPosition);
    }
}
