using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = rotationSpeed * Time.deltaTime; 
        transform.Rotate(xRot, 0, 0);
    }
}
