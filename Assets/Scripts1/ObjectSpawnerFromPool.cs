
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

        private int testCount;

        private void Awake()
        {
            Instance = this; // singleton makes us to reach this class's public methods and attributes from other classes
        }

        private void Start()
        {
            // comment other tests when you test one of them
            
            
            //TestObjectCreation(); // test 1
            
            //TestObjectCreation2(); // test 2
            
            /* test 2*/
            InitializePool(); // create object amount of objectAmount at start of the game (fill the pool)
            StartCoroutine(SpawnObject()); // spawn object amount of spawnAmount every 0.001 seconds
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
        
        // in this test we can see how much time it cost to create objectAmount object
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
        
        // (spawn needed amount and pop and push to pool immediately)
        private void TestObjectCreation2()
        {
            for (int i = 0; i < objectAmount; i++)
            {
                var createdObject = Instantiate(cubePrefab);
                createdObject.SetActive(false);
                objectPool.Enqueue(createdObject);
            }
            
            for (int i = 0; i < spawnTimeAmount; i++)
            {
                var popObject = PopObjectFromPool();
                PushObjectToPool(popObject);
                testCount++;
                //Debug.Log("c"+ testCount);
            }
            
            if (testCount == spawnTimeAmount)
            {
                Debug.Log("Time With Pool: " + Time.realtimeSinceStartup);
            }
        }
        
        // in this test we could do the calculations
        private IEnumerator SpawnObject()
        {
            while (testCount != spawnTimeAmount)
            {
                var spawnedObject = PopObjectFromPool(); // get available object from pool
                testCount++;
                
                // set random position for x and z between [-2,3)
                float randomPositionX = Random.Range(-2, 3);
                float randomPositionZ = Random.Range(-2, 3);
                var randomPosition = new Vector3(randomPositionX, transform.position.y, randomPositionZ);
                spawnedObject.transform.position = randomPosition; // give the random position pop object

                if (testCount == spawnTimeAmount - 1)
                {
                    Debug.Log(Time.realtimeSinceStartup); // show the time in console
                }
                
                yield return new WaitForSeconds(0.001f);
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
            pushedObject.SetActive(false); // deactivate in game world pushed object
            objectPool.Enqueue(pushedObject); // put back to the pool
        }
    }
}

