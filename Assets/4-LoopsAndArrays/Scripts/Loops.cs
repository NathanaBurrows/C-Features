using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoopsArrays
{

    public class Loops : MonoBehaviour
    {
        public float frequency = 3;
        public float amplitude = 6;
        public GameObject[] spawnPrefabs;
        public float spawnRadius = 5f;
        public string message = "Print This";
        public float printTime = 2f;
        public int spawnAmount = 10;

        private float timer = 0;

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
        // Use this for initialization
        void Start()
        {
            SpawnObjectsWithSine();
 //           int iteration = 0;
 //       while (iteration < 9000)
 //           {
 //                print(message);
 //                iteration++;
 //           }
    }
        // Update is called once per frame
        void Update()
        {
            /*
            timer += Time.deltaTime;
            while (timer <= printTime)
                {
                    print("PUT THE COOKIE DOWN ");
                    break;
                }
            */
        }

        void SpawnObjectsWithSine()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                int randomIndex = Random.Range(0, spawnPrefabs.Length);
                GameObject randomPrefab = spawnPrefabs[randomIndex];
                GameObject clone = Instantiate(randomPrefab);
                MeshRenderer rend = clone.GetComponent<MeshRenderer>();
                float r = Random.Range(0, 2);
                float g = Random.Range(0, 2);
                float b = Random.Range(0, 2);
                rend.material.color = new Color(r, g, b);
                float x = Mathf.Sin(i * frequency) * amplitude;
                float y = i;
                float z = 0;
                Vector3 randomPos = transform.position + new Vector3(x, y, z);
                randomPos.z = 0;
                clone.transform.position = randomPos;
            }
        }



        void SpawnObjects()
        {
            /*
            for(int i = 0; i < spawnAmount; i++)
            {
                GameObject clone = Instantiate(spawnPrefab);
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                randomPos.z = 0;
                clone.transform.position = randomPos;
            }
            */
        }  
    }
}