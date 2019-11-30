using UnityEngine;

public class 怪物移動目標點 : MonoBehaviour
{
    public Transform[] posints;

    private void Awake()
    {
        posints = new Transform[transform.childCount];
        for (int i = 0; i < posints.Length; i++)
        {
            posints[i] = transform.GetChild(i);
        }
    }
}
