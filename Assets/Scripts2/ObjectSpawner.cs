
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
        private int count;
        private int testCount;
        
        private void Start()
        {
            // comment StartCoroutine when you test
            // comment TestObjectCreation when you don't test

            //TestObjectCreation(); // create object amount of objectAmount at start of the game
            
            StartCoroutine(SpawnObject()); // spawn object amount of spawnAmount every 0.02 seconds
        }
        
        // how much time it cost to create spawnTimeAmount object
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
                Debug.Log("Object Creation Time Without Pool: " + Time.realtimeSinceStartup);
            }
        }

        private IEnumerator SpawnObject()
        {
            while (count != spawnTimeAmount)
            {
                var spawnedObject = Instantiate(cubePrefab); // create new object (Instantiate creates copy of prefab)
                count++;
            
                // set random position for x and z between [-2,3)
                float randomPositionX = Random.Range(-2, 3);
                float randomPositionZ = Random.Range(-2, 3);
                var randomPosition = new Vector3(randomPositionX, transform.position.y, randomPositionZ);
        
                // set random force for x and z between [-7,8) for y between [8,17)
                float forceX = Random.Range(-7, 8);
                float forceY = Random.Range(16 * 0.5f, 17);
                float forceZ = Random.Range(-7, 8);

                var force = new Vector3(forceX, forceY, forceZ);

                spawnedObject.transform.position = randomPosition; // give the random position pop object
                var rb = spawnedObject.GetComponent<Rigidbody>(); // get pop object rigidbody

                rb.velocity = force; // add velocity
                rb.angularVelocity = force; // turning around itself
            
                //Debug.Log("COUNT: " + count);
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
}

