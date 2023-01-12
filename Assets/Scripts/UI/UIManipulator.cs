using UnityEngine;

public class UIManipulator : MonoBehaviour
{
    public void Show(GameObject anObject)
    {
        anObject.SetActive(true);
    }

    public void Hide(GameObject anObject)
    {
        anObject.SetActive(false);
    }
}
