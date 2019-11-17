using UnityEngine;

/// <summary>
/// 儲存敵人要移動到全部定點位置
/// </summary>
public class LocationPoint : MonoBehaviour
{
    [Tooltip("儲存敵人要移動到定點位置")]public static Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount];
        //將所有子物件存入陣列裡
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
