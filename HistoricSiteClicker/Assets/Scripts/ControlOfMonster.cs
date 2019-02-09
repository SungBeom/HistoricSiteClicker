using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlOfMonster : MonoBehaviour {

    public Animator Hero;
    public Animator Monster;

    public GameObject monsterImage;
    public GameObject monsterHPImage;
    public GameObject StageText;

    
    //  차후 저장된 정보를 통한 초기화에 활용
    //public void Start()
    //{
    //
    //}
    public void Update()
    {
        int monsterHP = Monster.GetInteger("MonsterHP");
        int monsterTotalHP = Monster.GetInteger("MonsterTotalHP");

        //  check monster die
        if (Monster.GetInteger("MonsterHP") <= 0)
        {
            MonsterStageUp();
            MonsterHPInit();
            MonsterChange();
            MonsterStage();
            //Debug.Log("boss die and change");

            monsterHP = Monster.GetInteger("MonsterHP");
            monsterTotalHP = Monster.GetInteger("MonsterTotalHP");
        }

        ChangeHPImage(monsterTotalHP, monsterHP);
        //  자동 공격시 피격 당함을 추가 해야하나..
    }
    //  공격 당함 
    //  todo : 
    public void BeAttacked()
    {
        Monster.SetTrigger("MonsterHitTrigger");

        int monsterHP = Monster.GetInteger("MonsterHP");
        int monsterTotalHP = Monster.GetInteger("MonsterTotalHP");
        int heroDamage = Hero.GetInteger("NormalAttackDamage");


        Monster.SetInteger("MonsterHP", monsterHP - heroDamage);

        //  check monster die
        if (Monster.GetInteger("MonsterHP") <= 0)
        {
            MonsterStageUp();
            MonsterHPInit();
            MonsterChange();
            MonsterStage();
            //Debug.Log("boss die and change");

            monsterHP = Monster.GetInteger("MonsterHP");
            monsterTotalHP = Monster.GetInteger("MonsterTotalHP");
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
        int stage = Monster.GetInteger("MonsterStage");
        int HP = 1000 * stage;// * stage;
        Monster.SetInteger("MonsterHP", HP);
        Monster.SetInteger("MonsterTotalHP", HP);
    }
    //  유적 단계 변화
    //  유적 파괴시 단계 증가
    void MonsterStageUp()
    {
        int stage = Monster.GetInteger("MonsterStage");
        Monster.SetInteger("MonsterStage", stage + 1);
    }
    //  몬스터 변경
    //  스테이지 확인 후 변경
    void MonsterChange()
    {
        string monsterImagePath = string.Format("Images/Monster/{0}", Monster.GetInteger("MonsterStage"));
        monsterImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(monsterImagePath);

    }
    //  유적지 단계 변경
    void MonsterStage()
    {
        int stage = Monster.GetInteger("MonsterStage");
        StageText.GetComponent<Text>().text = stage.ToString();
    }
}
