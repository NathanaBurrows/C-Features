using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collisions
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Reflect : MonoBehaviour
    {
        private Rigidbody2D rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            Vector3 inDirection = rigid.velocity.normalized;
            ContactPoint2D contact = other.contacts[0];
            Vector3 inNormal = other.contacts[0].normal;
            Vector3 reflect = Vector3.Reflect(inDirection, inNormal);
            Vector3 newForce = reflect * rigid.velocity.magnitude;
            rigid.velocity = newForce;
        }
    }
}