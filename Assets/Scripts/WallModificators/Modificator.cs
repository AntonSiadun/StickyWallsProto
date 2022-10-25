using UnityEngine;

public class Modificator : MonoBehaviour
{
    [SerializeField] protected bool turnBackOnTouch = true;
    protected Character character;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(turnBackOnTouch)
                character.TurnBack();
            character.Stop();
            character.Snap();
            OnTouch();
        }
    }

    protected virtual void OnTouch() { }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Leave Trigger "+gameObject.name);
            character.Unsnap();
            OnLeave();
        }
    }

    protected virtual void OnLeave() { }
}
