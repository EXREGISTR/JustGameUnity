using System;
using UnityEngine;

public class PlayerStrategy : AbstractStrategy
{
    #region Constants
    // вектор силы отскока от стены
    private const float X = 100, Y = 100, Z = 10000;
    // вектор силы отскока от границы наклона горки
    private const float X1 = 8000, Y1 = 100, Z1 = 100;
    #endregion

    public static event Action PlayerDestroyEvent;

    [SerializeField] private PlayerMovement _PlayerMovement;

    private Rigidbody _playerRigidBody;
    private Vector3 _vectorForce;

    private void Awake() => _playerRigidBody = GetComponent<Rigidbody>();

    #region Methods For Collision Controller
    public override void CollisionEnter(string collisionTag)
    {
        switch (collisionTag)
        {
            case "Block":
                DeleteObject(); 
                break;
            case "Obstacle":
                DeleteObject(); 
                break;
            case "Left Wall":
                _vectorForce = new Vector3(-X, Y, Z);
                KickBack(); 
                break;
            case "Right Wall":
                _vectorForce = new Vector3(-X, Y, -Z);
                KickBack(); 
                break;
            default:
                break;
        }
    }
    public override void CollisionStay(string collisionTag)
    {
        // если игрок на платформе, то он может прыгать
        if (collisionTag == "Platform")
            _PlayerMovement.CanJump = true;
    }
    public override void CollisionExit(string collisionTag)
    {
        // как только игрок покидает коллайдер платформы, он больше не может нажать на кнопку "прыгать"
        if (collisionTag == "Platform")
            _PlayerMovement.CanJump = false;
    }
    #endregion

    #region Methods For Trigger Controller
    public override void TriggerEnter(string triggerTag)
    {
        if (triggerTag == "OnKickBack")
        { 
            _vectorForce = new Vector3(X1, Y1, Z1);
            KickBack();
        }
    }
    public override void TriggerStay(string triggerTag)
    {
        // здесь могла быть какая нибудь логика
    }
    public override void TriggerExit(string triggerTag)
    {
        // здесь могла быть какая нибудь логика
    }
    #endregion

    #region Methods
    private void KickBack() => _playerRigidBody.AddForce(_vectorForce);
    private void DeleteObject()
    {
        PlayerDestroyEvent?.Invoke();
        Destroy(gameObject);
    }
    #endregion
}