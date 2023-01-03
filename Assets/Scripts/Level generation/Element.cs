using UnityEngine;

[CreateAssetMenu(menuName = "Level element",fileName = "Element")]
public class Element : ScriptableObject
{
    public GameObject Wall;
    public Vector3 Start;
    public Vector3 End;
}
