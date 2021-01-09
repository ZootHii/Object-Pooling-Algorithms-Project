
// it makes used objects available again
/* POOLED OBJECT CONTROLLER PUSHES BACK TO POOL EVERY OBJECT THAT HITS TRIGGER */

namespace Scripts1
{
    using UnityEngine;

    public class PooledObjectController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Trigger")) // if object hits the trigger push it back to the pool
            {
                ObjectSpawnerFromPool.Instance.PushObjectToPool(gameObject);
            }
        }
    }
}


