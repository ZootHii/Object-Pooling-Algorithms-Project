
// it creates spawnTimeAmount new object and spawns spawnTimeAmount
/* NON POOL OBJECT SPAWNER CREATES AMOUNT OF spawnTimeAmount OBJECT */

using System.Collections;
using UnityEngine;

namespace Scripts2
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private int spawnTimeAmount;
        private int testCount;

        private void Start()
        {
            // comment other tests when you test one of them
            
            
            // create object amount of objectAmount at start of the game
            //TestObjectCreation(); // test 1
            
            //TestObjectCreation2(); // test 2
            
            // spawn object amount of spawnAmount every 0.001 seconds
            StartCoroutine(SpawnObject()); // test 3
        }
        
        // in this test how much time it cost to create spawnTimeAmount object
        private void TestObjectCreation()
        {
            for (int i = 0; i < spawnTimeAmount; i++)
            {
                var createdObject = Instantiate(cubePrefab);
                createdObject.SetActive(false);
                //Destroy(createdObject); // did not add if we add it cost more
                testCount++;
            }

            if (testCount == spawnTimeAmount)
            {
                //Debug.Log("Object Creation Time Without Pool: " + Time.realtimeSinceStartup);
            }
        }
        
        // in this test unity crashes (spawn and destroy immediately)
        private void TestObjectCreation2()
        {
            for (int i = 0; i < spawnTimeAmount; i++)
            {
                var createdObject = Instantiate(cubePrefab);
                Destroy(createdObject);
                testCount++;
                //Debug.Log("c"+ testCount);
            }
            
            if (testCount == spawnTimeAmount)
            {
                Debug.Log("Time With Pool: " + Time.realtimeSinceStartup);
                /*time = Time.realtimeSinceStartup;
                timeText.text = "Time : "+ time;*/
            }
        }

        // in this test we could do the calculations
        private IEnumerator SpawnObject()
        {
            while (testCount != spawnTimeAmount)
            {
                var spawnedObject = Instantiate(cubePrefab); // create new object (Instantiate creates copy of prefab)
                testCount++;
                
                // set random position for x and z between [-2,3)
                float randomPositionX = Random.Range(-2, 3);
                float randomPositionZ = Random.Range(-2, 3);
                var randomPosition = new Vector3(randomPositionX, transform.position.y, randomPositionZ);
                spawnedObject.transform.position = randomPosition; // give the random position pop object
                
                if (testCount == spawnTimeAmount - 1)
                {
                    Debug.Log(Time.realtimeSinceStartup);  // show the time in console
                }
                
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
}

