using UnityEngine;

public class CollisionAndTriggerController : MonoBehaviour
{
    [SerializeField] private AbstractStrategy _Strategy;

    #region PrivateFields
    private string _collisionTag;
    private string _triggerTag;
    #endregion

    #region CollisionLogic
    private void OnCollisionEnter(Collision collision)
    {
        _collisionTag = collision.gameObject.tag;
        _Strategy.CollisionEnter(_collisionTag);
    }
    private void OnCollisionStay(Collision collision)
    {
        _collisionTag = collision.gameObject.tag;
        _Strategy.CollisionStay(_collisionTag);
    }
    private void OnCollisionExit(Collision collision)
    {
        _collisionTag = collision.gameObject.tag;
        _Strategy.CollisionExit(_collisionTag);
    }
    #endregion

    #region TriggerLogic
    private void OnTriggerEnter(Collider trigger)
    {
        _triggerTag = trigger.gameObject.tag;
        _Strategy.TriggerEnter(_triggerTag);
    }
    private void OnTriggerStay(Collider trigger)
    {
        _triggerTag = trigger.gameObject.tag;
        _Strategy.TriggerStay(_triggerTag);
    }
    private void OnTriggerExit(Collider trigger)
    {
        _triggerTag = trigger.gameObject.tag;
        _Strategy.TriggerExit(_triggerTag);
    }
    #endregion
}

