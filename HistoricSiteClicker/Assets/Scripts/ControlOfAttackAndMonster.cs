using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlOfAttackAndMonster : MonoBehaviour {

    public Animator Hero;
    public Animator Monster;
    public GameObject monsterHPImage;

    //  기본 공격
    public void Attack()
    {
        Hero.SetTrigger("NormalAttackTrigger");
        Monster.SetTrigger("MonsterHitTrigger");

        int monsterHP = Monster.GetInteger("MonsterHP");
        int monsterTotalHP = Monster.GetInteger("MonsterTotalHP");
        int heroDamage = Hero.GetInteger("NormalAttackDamage");


        Monster.SetInteger("MonsterHP", monsterHP - heroDamage);
        
        //  check monster die
        if (Monster.GetInteger("MonsterHP") <= 0)
        {
            MonsterChangeAndInit();
            //Debug.Log("boss die and change");
        }
        
        //  change hp image
        ChangeHPImage(monsterTotalHP, monsterHP);
    }

   void ChangeHPImage(float totalHP, float currentHP)
    {
        float currentImage = currentHP / totalHP;
        monsterHPImage.GetComponent<Image>().fillAmount = (float)System.Math.Round(currentImage, 2);
    }


    void MonsterChangeAndInit()
    {
        Monster.SetInteger("MonsterHP", 1000);
    }
    //  단계에 따른 유물 획득
    void GetRelics()
    {

    }
}
