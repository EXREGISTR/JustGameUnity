using UnityEngine;

public class InputController : MonoBehaviour
{
    #region Constants
    // оси (для удобства получения)
    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";
    #endregion

    [SerializeField] private PlayerMovement _PlayerMovement;

    private void FixedUpdate()
    { 
        Move();
        if (_PlayerMovement.CanJump && Input.GetKey(KeyCode.Space))
            Jump();
    }
    private void Move()
    {
        _PlayerMovement.Move(verticalAxis: Input.GetAxis(Vertical), horizontalAxis: Input.GetAxis(Horizontal));
    }
    private void Jump()
    {
        _PlayerMovement.Jump();
    }
}
