using UnityEngine;
/// <summary>
/// 卡片管理(擁有全部的卡片if玩家有就讓他為true)
/// </summary>
public class CardManager : MonoBehaviour
{
    public HeroDesign[] Illustration;
    public HeroDesign[] openCaed;

    private void Start()
    {
        int a=0;
        for (int i = 0; i < Illustration.Length; i++)
        {
            if (Illustration[i].holdCrad == true)
            {
                a++;
            }
        }
        openCaed = new HeroDesign[a];
        HoldCradUpdate();
    }

    private void HoldCradUpdate()
    {
        for (int i = 0; i < openCaed.Length; i++)
        {
            for (int j = 0; j < Illustration.Length; j++)
            {
                if (Illustration[i].holdCrad == true)
                {
                    openCaed[i] = Illustration[j];
                    break;
                }
            }
        }
    }
}