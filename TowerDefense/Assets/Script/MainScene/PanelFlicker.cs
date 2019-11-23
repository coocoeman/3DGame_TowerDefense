using UnityEngine;

public class PanelFlicker : MonoBehaviour
{
    public GameObject panel_1,panel_2,panel_3;
    public AudioSource backMusic;

    public void Open1()
    {
        panel_1.SetActive(false);
        panel_2.SetActive(true);
    }

    public void Open2()
    {
        panel_2.SetActive(false);
        panel_3.SetActive(true);
        backMusic.Play();
    }

    public void Shut()
    {
        gameObject.SetActive(false);
    }
}
