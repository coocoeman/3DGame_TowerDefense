using UnityEngine;

public class HeroCardsTeam : MonoBehaviour
{
    public HeroDesign[] hds;

    /// <summary>
    /// 隊伍中的能力值設定
    /// </summary>
    public static HeroDesign[] HDS ;

    void Start()
    {
        HDS = new HeroDesign[hds.Length];
        Team();
    }

    private void Team()
    {
        for (int i = 0; i < hds.Length; i++)
        {
            SetCaedTeam(hds[i], i);
        }
    }

    public void SetCaedTeam(HeroDesign HD,int i)
    {
        HDS[i] = HD;
        HDS[i].prefab = Resources.Load("Hero/"+HDS[i].name, typeof(object)) as GameObject;
    }

}
