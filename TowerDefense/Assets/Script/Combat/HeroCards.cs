using UnityEngine;

public class HeroCards : MonoBehaviour
{
    GenerateHeroManagement management;
    //public Transform tra;

    void Start()
    {
        management = GenerateHeroManagement.instance;
    }

    public void CallHeroCards1(int i)
    {
        management.SetHero(HeroCardsTeam.HeroDesigns[i]);
        //Instantiate(HeroCardsTeam.HeroDesigns[0].prefab,tra);
    }

    /// <summary>
    /// 卡牌拖移
    /// </summary>
    public void CardTow(RectTransform rt)
    {
        Vector3 mp = Input.mousePosition;
        mp.y = 0;
        Vector3 pos = Camera.main.WorldToScreenPoint(mp);
        //tra.position = pos;

    }
}
