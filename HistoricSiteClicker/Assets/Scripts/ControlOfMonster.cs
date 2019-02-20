using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlOfMonster : MonoBehaviour {

    public Animator Hero;
    public Animator monster;
    
    public GameObject monsterImage;
    public GameObject monsterHPImage;
    public GameObject StageText;
    ControlOfRelics controlOfRelics;
    
    //  차후 저장된 정보를 통한 초기화에 활용
    public void Start()
    {
        controlOfRelics = FindObjectOfType<ControlOfRelics>();
    }

    //  공격 당함 
    //  todo : 
    public void BeAttacked(int damage)
    {
        //Monster.SetTrigger("MonsterHitTrigger");

        int monsterHP = monster.GetInteger("MonsterHP");
        int monsterTotalHP = monster.GetInteger("MonsterTotalHP");
        //int heroDamage = Hero.GetInteger("NormalAttackDamage");


        monster.SetInteger("MonsterHP", monsterHP - damage);

        //  check monster die
        if (monster.GetInteger("MonsterHP") <= 0)
        {
            MonsterStageUp();
            MonsterHPInit();
            MonsterChange();
            MonsterStage();
            //Debug.Log("boss die and change");

            monsterHP = monster.GetInteger("MonsterHP");
            monsterTotalHP = monster.GetInteger("MonsterTotalHP");
        }

        //  change hp image
        ChangeHPImage(monsterTotalHP, monsterHP);
    }


    // check monster hp
    void ChangeHPImage(float totalHP, float currentHP)
    {
        float currentImage = currentHP / totalHP;
        monsterHPImage.GetComponent<Image>().fillAmount = (float)System.Math.Round(currentImage, 2);
    }


    //  몬스터 체력 초기화(stage에 따른 체력 변화)
    void MonsterHPInit()
    {
        int stage = monster.GetInteger("MonsterStage");
        int HP = 1 * stage;// * stage;
        monster.SetInteger("MonsterHP", HP);
        monster.SetInteger("MonsterTotalHP", HP);
    }


    //  유적 단계 변화
    //  유적 파괴시 단계 증가
    void MonsterStageUp()
    {
        int stage = monster.GetInteger("MonsterStage");
        monster.SetInteger("MonsterStage", stage + 1);
        if (stage % 20 == 0)
        {
            //Debug.Log(" Get Relics : " + "stage: " + stage + "----- stage%20 : " + stage % 20);
            controlOfRelics.GetRelics(stage);
        }
    }


    //  몬스터 변경
    //  스테이지 확인 후 변경
    void MonsterChange()
    {
        string monsterImagePath = string.Format("Images/Monster/{0}", monster.GetInteger("MonsterStage"));
        monsterImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(monsterImagePath);
    }


    //  유적지 단계 변경
    void MonsterStage()
    {
        int stage = monster.GetInteger("MonsterStage");
        StageText.GetComponent<Text>().text = stage.ToString();
    }
}
