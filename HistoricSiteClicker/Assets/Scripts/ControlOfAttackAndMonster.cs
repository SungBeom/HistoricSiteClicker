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

        if (monsterHP > 0 )
        {
            Monster.SetInteger("MonsterHP", monsterHP - heroDamage);

            //  change hp image
            ChangeHPImage(monsterTotalHP, monsterHP);
        }
        else
        {
            MonsterChangeAndInit();
            //Debug.Log("boss die and change");
        }
        //Debug.Log(monsterHP);
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
