using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed;
    
    private void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        
        
        transform.Rotate(Vector3.up,horInput*rotateSpeed*Time.deltaTime);
    }
}
