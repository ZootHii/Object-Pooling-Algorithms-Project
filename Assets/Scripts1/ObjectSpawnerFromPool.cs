
// it creates objectAmount object and spawns spawnTimeAmount with reusable objects
/* POOL OBJECT SPAWNER CREATES NEEDED AMOUNT OF OBJECT "objectAmount" AND REUSE AVAILABLE
 OBJECTS IN POOL FOR spawnTimeAmount TIMES */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts1
{
    public class ObjectSpawnerFromPool : MonoBehaviour
    {
        public static ObjectSpawnerFromPool Instance;
        private readonly Queue<GameObject> objectPool = new Queue<GameObject>();
        [SerializeField] private int objectAmount;
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private int spawnTimeAmount;
        private int count;
        private int testCount;
        
        private void Awake()
        {
            Instance = this; // singleton makes us to reach this class's public methods and attributes from other classes
        }

        private void Start()
        {
            // comment StartCoroutine and InitializePool when you test
            // comment TestObjectCreation when you don't test
            
            //TestObjectCreation();
            
            InitializePool(); // create object amount of objectAmount at start of the game
            StartCoroutine(SpawnObject()); // spawn object amount of spawnAmount every 0.02 seconds
        }
        
        // how much time it cost to create objectAmount object
        private void TestObjectCreation()
        {
            for (int i = 0; i < objectAmount; i++)
            {
                var createdObject = Instantiate(cubePrefab);
                createdObject.SetActive(false);
                testCount++;
            }
            
            if (testCount == objectAmount)
            {
                Debug.Log("Object Creation Time With Pool: " + Time.realtimeSinceStartup);
            }
        }
        
        private void InitializePool()
        {
            for (int i = 0; i < objectAmount; i++)
            {
                var createdObject = Instantiate(cubePrefab);
                createdObject.SetActive(false);
                objectPool.Enqueue(createdObject);
            }
        }

        private IEnumerator SpawnObject()
        {
            while (count != spawnTimeAmount)
            {
                var spawnedObject = PopObjectFromPool(); // get available object from pool
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

        public GameObject PopObjectFromPool()
        {
            var popObject = objectPool.Dequeue(); // get first object from pool
            popObject.SetActive(true); // activate in game world pop object
            return popObject;
        }

        public void PushObjectToPool(GameObject pushedObject)
        {
            //obj.transform.position = new Vector3(0, 0, 0); // set pushed object to 
            pushedObject.SetActive(false); // deactivate in game world pushed object
            objectPool.Enqueue(pushedObject); // put back to the pool
        }
    }
}

