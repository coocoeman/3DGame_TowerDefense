using UnityEngine;

public class HeroCards : MonoBehaviour
{
    GenerateHeroManagement management;
    

    void Start()
    {
        management = GenerateHeroManagement.instance;
    }

    public void CallHeroCards1()
    {
        management.SetHero(HeroCardsTeam.HeroDesigns[0]);
    }
    public void CallHeroCards2()
    {
        management.SetHero(HeroCardsTeam.HeroDesigns[1]);
    }
    public void CallHeroCards3()
    {
        management.SetHero(HeroCardsTeam.HeroDesigns[2]);
    }
    public void CallHeroCards4()
    {
        management.SetHero(HeroCardsTeam.HeroDesigns[3]);
    }
    public void CallHeroCards5()
    {
        management.SetHero(HeroCardsTeam.HeroDesigns[4]);
    }
    public void CallHeroCards6()
    {
        management.SetHero(HeroCardsTeam.HeroDesigns[5]);
    }

    public void CardTow()
    {
        Debug.Log("拖動");
    }
}
