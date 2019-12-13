using UnityEngine;

public class 關卡命令 : MonoBehaviour
{
    private AudioSource 遊戲音樂;
    public AudioClip 關卡背景音樂;

    public GameObject 關卡資訊畫面;

    private void Start()
    {
        遊戲音樂 = GameObject.Find("遊戲總管").GetComponent<AudioSource>();
        遊戲音樂.clip = 關卡背景音樂;
        遊戲音樂.Play();
        介紹方法();
    }

    public void 介紹方法()
    {
        關卡資訊畫面.SetActive(true);
        Time.timeScale = 0f;
        
    }


}
