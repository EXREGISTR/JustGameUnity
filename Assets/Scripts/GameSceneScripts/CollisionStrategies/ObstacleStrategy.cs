using UnityEngine;

public class ObstacleStrategy : AbstractStrategy
{
    #region SerializeFields
    [SerializeField] private GameUI _GameUI;
    [SerializeField] private float Acceleration;
    #endregion

    public delegate void UpdatePointsHandler(float pointsCount);
    public static event UpdatePointsHandler OnUpdatePointsEvent;
    
    #region PrivateFields
    private Rigidbody _obstacleRigidBody;
    private Vector3 _vectorForce;
    #endregion

    private void Awake() => _obstacleRigidBody = GetComponent<Rigidbody>();

    #region MethodsForCollisionController
    public override void CollisionEnter(string collisionTag)
    {
        switch (collisionTag)
        {
            case "SpeedMagnifer":
                _vectorForce = Vector3.right * Acceleration;
                AddAcceleration(); 
                break;
            case "Block":
                DeleteObject(); 
                break;
            default:
                break;
        }
    }
    public override void CollisionStay(string collisionTag)
    {
        // здесь могла быть какая нибудь логика
    }
    public override void CollisionExit(string collisionTag)
    {
        // здесь могла быть какая нибудь логика
    }
    #endregion

    #region MethodsForTriggerController
    public override void TriggerEnter(string triggerTag)
    {
        // здесь могла быть какая нибудь логика
    }
    public override void TriggerStay(string triggerTag)
    {
        // здесь могла быть какая нибудь логика
    }
    public override void TriggerExit(string triggerTag)
    {
        if (triggerTag == "UpdPoints")
        {
            // AddPoints();
            OnUpdatePointsEvent?.Invoke(GetRandomPoints());
        }
    }
    #endregion

    #region Methods
    private void AddAcceleration() => _obstacleRigidBody.AddRelativeForce(_vectorForce, ForceMode.Acceleration);
    private void DeleteObject() => Destroy(gameObject);
    private float GetRandomPoints() => Random.Range(1, 15);
    #endregion
}