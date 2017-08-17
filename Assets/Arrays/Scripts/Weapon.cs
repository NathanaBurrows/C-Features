using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrays
{
    public class Weapon : MonoBehaviour
    {
        public int damage = 10;
        public int maxBullets = 30;
        public float bulletSpeed = 20f;
        public float fireInterval = 0.2f;
        public GameObject bulletPrefab;
        public Transform spawnPoint;

        private Bullet[] spawnedBullets;
        private int currentBullets = 0;
        private bool isFired = false;
        private Transform target;

        // Use this for initialization
        void Start()
        {
            spawnedBullets = new Bullet[maxBullets];
        }

        // Update is called once per frame
        void Update()
        {
            if (isFired && currentBullets < maxBullets)
            {
                StartCoroutine(Fire());
            }
        }

        IEnumerator Fire()
        {
            isFired = true;

            SpawnBullet();

            yield return new WaitForSeconds(fireInterval);

            isFired = false;
        }

        void SpawnBullet()
        {
            //Instantiate a bullet clone
            GameObject clone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            //Make a direction that goes to target
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            //Rotate the barrell
            Vector3 eulerAngles = transform.eulerAngles;
            float angle = Vector3.Angle(Vector3.right, direction);
            eulerAngles.z = angle;
            transform.eulerAngles = eulerAngles;
            //Grab bullet script from clone
            Bullet bullet = clone.GetComponent<Bullet>();
            //Send bullet to target
            bullet.direction = direction;
            //Store bullet in Array
            spawnedBullets[currentBullets] = bullet;
            //Increment currentBullets
            currentBullets++;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}