using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region SerializeFields
    [SerializeField] private float Speed = 2;
    [SerializeField] private float JumpHeight = 5;
    [HideInInspector] public bool CanJump { get; set; }
    #endregion

    private Rigidbody _rigidBody;
    private Vector3 _vectorMove;
    // параметры вектора движения
    private float X, Y, Z;

    private void Awake() => _rigidBody = GetComponent<Rigidbody>();

    #region Methods
    public void Move(float verticalAxis, float horizontalAxis)
    {
        X = verticalAxis * Speed; 
        Y = _rigidBody.velocity.y; 
        Z = horizontalAxis * Speed;

        _vectorMove = new Vector3(-X, Y, Z);
        SetVelocity();
    }
    public void Jump()
    {
        _vectorMove = Vector3.up * JumpHeight;
        SetVelocity();
    }
    private void SetVelocity()
    {
        _rigidBody.velocity = _vectorMove;
    }
    #endregion
}