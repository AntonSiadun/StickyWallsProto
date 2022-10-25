using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    public bool InJump
    {
        get { return _inJump; }
    }
    [SerializeField] protected Character character;
    [SerializeField] protected int extraJumps;
    [SerializeField] protected float jumpTime;
    [SerializeField] private float _multipierLongJumpForce = 0.01f;
    protected int extraJumpsCounter;
    protected float jumpTimer;
    private bool _inJump = false;

    private void Update()
    {
        if (character.IsGrounded)
            ResetExtraJumpsCounter();

        if (isPressedAtWall())
        {
            Debug.Log("Jump from wall");
            ReleaseJump();
            return;
        }
        else if (isPressedAndHadExtraJumps())
        {
            Debug.Log("TurnBack");
            character.TurnBack();
            ReleaseJump();
            extraJumpsCounter--;
            return;
        }

        if (_inJump)
        {
            if (jumpTimer > 0)
            {
                Debug.Log("Long Jump part");
                character.Jump(_multipierLongJumpForce);
                jumpTimer -= Time.deltaTime;
            }
            else
            {
                Debug.Log("LOngJumpEnd");
                _inJump = false;
                ResetJumpTimer();
            }
        }

        if (isPressingEnded())
        {
            Debug.Log("PressEnd");
            ResetJumpTimer();
            _inJump = false;
        }
    }

    #region Boolean conditions
    protected abstract bool isPressedAtWall();
    protected abstract bool isPressedAndHadExtraJumps();
    protected abstract bool isPressingEnded();
    #endregion

    private void ReleaseJump()
    {
        character.Stop();
        character.Jump(0.5f);
        _inJump = true;
    }

    private void ResetJumpTimer()
    {
        jumpTimer = jumpTime;
    }

    private void ResetExtraJumpsCounter()
    {
        extraJumpsCounter = extraJumps;
    }
}
