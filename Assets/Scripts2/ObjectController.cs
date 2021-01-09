
// it destroys spawnTimeAmount object
/* NON POOL OBJECT CONTROLLER DESTROYS EVERY CREATED OBJECT THAT HITS TO TRIGGER */

using UnityEngine;

namespace Scripts2
{
    public class ObjectController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Trigger")) // if object hits the trigger destroy it
            {
                Destroy(gameObject);
            }
        }
    }
}



