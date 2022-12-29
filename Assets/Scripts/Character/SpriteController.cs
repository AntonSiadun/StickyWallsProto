using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public void ReverseScale()
    {
        transform.localScale = new Vector3(-transform.localScale.x,
                                            transform.localScale.y,
                                            transform.localScale.z);
    }
}
