using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteController _controller;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<SpriteController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            _animator.SetTrigger("OnGround");
        }
        else if(collision.CompareTag("Wall"))
        {
            _animator.SetTrigger("OnWall");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetTrigger("OnAir");
        if (collision.CompareTag("Wall"))
        {
            _controller.ReverseScale();
        }
    }
}
