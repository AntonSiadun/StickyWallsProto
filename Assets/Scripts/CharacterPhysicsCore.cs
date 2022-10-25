using UnityEngine;

public class CharacterPhysicsCore
{
    private Rigidbody2D _rigidbody;
    private float _gravity;
    
    public CharacterPhysicsCore(Rigidbody2D rigidbody)
    {
        _rigidbody= rigidbody;
    }

    public void AddPulse(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

    public void ResetVelocity()
    {
        _rigidbody.velocity = Vector2.zero;
    }

    public void SetGravity(float gravityForce)
    {
        _gravity = gravityForce;
    }

    public void DisableGravity()
    {
        _rigidbody.gravityScale = 0f;
    }

    public void EnableGravity()
    {
        _rigidbody.gravityScale = _gravity;
    }

    public void SetVerticalVelocity(float vertical)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, vertical);
    }

    public void SetHorizontalVelocity(float horizontal)
    {
        _rigidbody.velocity = new Vector2(horizontal, _rigidbody.velocity.y);
    }
}