using UnityEngine;
public abstract class AbstractStrategy : MonoBehaviour
{
    public abstract void CollisionEnter(string collisionTag);
    public abstract void CollisionStay(string collisionTag);
    public abstract void CollisionExit(string collisionTag);

    public abstract void TriggerEnter(string triggerTag);
    public abstract void TriggerStay(string triggerTag);
    public abstract void TriggerExit(string triggerTag);
}
