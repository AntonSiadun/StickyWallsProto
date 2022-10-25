using UnityEngine;

public class Character : MonoBehaviour, IMovingCharacter
{
    public bool IsGrounded => _isGrounded;
    public float Direction => _direction.x;
    [SerializeField] private Vector2 _jumpPower;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private float _gravityForce = 1.2f;
    private CharacterPhysicsCore _physicsCore;
    private bool _isGrounded;
    private Transform _cachedTransform;
    private Vector2 _direction = new Vector2(1f, 1f);
    private void Awake()
    {
        var rb = GetComponent<Rigidbody2D>();
        _physicsCore = new CharacterPhysicsCore(rb);
        _cachedTransform = transform;
        _groundCheckRadius = GetComponent<BoxCollider2D>().bounds.size.y / 2;
        _physicsCore.SetGravity(_gravityForce);
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapArea(_cachedTransform.position + new Vector3(-_groundCheckRadius, _groundCheckRadius - 0.01f, 0f),
                                            _cachedTransform.position + new Vector3(_groundCheckRadius, -_groundCheckRadius, 0f),
                                                             LayerMask.GetMask("Ground"));
    }

    public void Jump()
    {
        Jump(1f);
    }

    public void Jump(float multipier)
    {
        _physicsCore.AddPulse(_jumpPower * _direction * multipier);
    }

    public void SetVerticalVelocity(float velocity)
    {
        _physicsCore.SetVerticalVelocity(velocity);
    }

    public void SetHorizontalVelocity(float velocity)
    {
        _physicsCore.SetHorizontalVelocity(velocity);
    }

    public void Stop()
    {
        _physicsCore.ResetVelocity();
    }

    public void Snap()
    {
        _physicsCore.DisableGravity();

    }
    public void Unsnap()
    {
        _physicsCore.EnableGravity();
    }

    public void TurnBack()
    {
        _direction = new Vector2(_direction.x * -1, _direction.y);
    }
}
