using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float rotationSpeed = 2f;

	// Update is called once per frame
	void Update ()
    {
        //Get Horizontal input
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        transform.position += transform.right * inputV * movementSpeed * Time.deltaTime;
        transform.eulerAngles += -Vector3.forward * inputH * rotationSpeed * Time.deltaTime;
	}
}
