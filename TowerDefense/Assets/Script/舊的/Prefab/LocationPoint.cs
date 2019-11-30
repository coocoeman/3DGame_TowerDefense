using UnityEngine;

/// <summary>
/// 儲存敵人目標定位點
/// </summary>
public class LocationPoint : MonoBehaviour
{
    /// <summary>
    /// 怪物目標定位點
    /// </summary>
    public static Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount];
        
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
