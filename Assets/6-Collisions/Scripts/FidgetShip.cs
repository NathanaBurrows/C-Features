﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colisions
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FidgetShip : MonoBehaviour
    {
        public float acceleration = 50f;
        public float rotateSpeed = 20f;

        private Rigidbody2D rigid;
        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        void Accelerate()
        {
            float inputV = Input.GetAxis("Vertical");
            rigid.AddForce(transform.up * inputV * acceleration);
        }

        void Rotate()
        {
            float inputH = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.back, rotateSpeed * inputH);
        }
        // Update is called once per frame
        void Update()
        {
            Accelerate();
            Rotate();
        }
    }
}