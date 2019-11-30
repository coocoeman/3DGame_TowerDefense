using UnityEngine;

public class HeroCards : MonoBehaviour
{
    private GameObject hero;

    /// <summary>
    /// 按下卡片執行 告知生成腳本 要生成的英雄 
    /// 並且生成一個英雄 要用來做拖曳的效果
    /// </summary>
    /// <param name="i"></param>
    public void CallHeroCards1(int i)
    {
        GenerateHeroManagement.instance.SetHero(HeroCardsTeam.HDS[i]);
        Vector3 v3 = Input.mousePosition;
        Quaternion q = new Quaternion(0, 180, 0, 0);
        hero = Instantiate(HeroCardsTeam.HDS[i].prefab, v3,q);
        hero.GetComponent<HeroDesign3D>().enabled = false;
    }

    /// <summary>
    /// 卡牌拖移 讓拖移用的英雄 跟著手指OR滑鼠走
    /// </summary>
    public void CardTow()
    {
        Vector3 v3 = Camera.main.WorldToScreenPoint(hero.transform.position);
        v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y,v3.z);
        v3 = Camera.main.ScreenToWorldPoint(v3);
        hero.transform.position = new Vector3(v3.x, 10, v3.z);
    }

    
    public void CardUP()
    {
        Destroy(hero);
    }
}
