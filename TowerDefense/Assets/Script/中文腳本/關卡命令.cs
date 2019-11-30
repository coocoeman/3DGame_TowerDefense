using UnityEngine;

public class 關卡命令 : MonoBehaviour
{
    public AudioSource 遊戲音樂;
    public AudioClip 關卡背景音樂;


    private void Start()
    {
        遊戲音樂.clip = 關卡背景音樂;
        遊戲音樂.Play();
    }
}
