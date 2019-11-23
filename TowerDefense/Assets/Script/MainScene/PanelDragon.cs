using UnityEngine;
using System;

public class PanelDragon : MonoBehaviour
{
    public GameObject panel_1,panel_2;
    public GameObject Dragon3D;
    [Range(0,5)]public float speed;
    
    void Update()
    {
        if (Dragon3D.transform.position.x >= 15)
        {
            panel_2.SetActive(true);
            return;
        }
        Dragon3D.transform.position += Vector3.right * Time.deltaTime * speed;
        Dragon3D.GetComponent<AudioSource>().volume = 0.5f-Math.Abs(Dragon3D.transform.position.x)/30;
    }

}
