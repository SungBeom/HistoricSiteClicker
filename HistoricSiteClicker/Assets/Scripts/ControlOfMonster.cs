using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlOfMonster : MonoBehaviour {
    private static ControlOfMonster instance;
    public static ControlOfMonster Instance
    {
        get { return instance; }
    }


    ControlOfRelics controlOfRelics;
    [SerializeField]
    private float lerpSpeed;

    void Awake()
    {
        instance = this;
    }


    public void Start()
    {
        controlOfRelics = FindObjectOfType<ControlOfRelics>();
        RelicsManager.Instance.monsterTotalHP = RelicsManager.Instance.monsterTotalHP * RelicsManager.Instance.stage;
        RelicsManager.Instance.monsterHP = RelicsManager.Instance.monsterTotalHP;
    }

    //  공격 당함 
    //  todo : 
    public void BeAttacked(int damage)
    {
        RelicsManager.Instance.monsterHP = RelicsManager.Instance.monsterHP - damage;
        //  check monster die
        if (RelicsManager.Instance.monsterHP <= 0)
        {
            MonsterStageUp();
            MonsterHPInit();
            MonsterChange();
            MonsterStage();
            //Debug.Log("boss die and change");
            RelicsManager.Instance.endOfTurnTime = RelicsManager.Instance.endOfTimeDefalut;
            RelicsManager.Instance.turnEndTimeText.text = string.Format("{0}", RelicsManager.Instance.endOfTimeDefalut);
        }
        //  change hp image
        ChangeHPImage(RelicsManager.Instance.monsterTotalHP, RelicsManager.Instance.monsterHP);
    }

    //  일정 시간안에 몬스터를 몹잡는 경우
    public void TimeOut()
    {
        MonsterStageDown();
        MonsterHPInit();
        MonsterChange();
        MonsterStage();

        ChangeHPImage(RelicsManager.Instance.monsterTotalHP, RelicsManager.Instance.monsterHP);
    }
    // check monster hp
    void ChangeHPImage(int totalHP, int currentHP)
    {
        float hpCurrent = (float)currentHP / (float)totalHP;
        //Debug.LogError(hpCurrent);
        RelicsManager.Instance.monsterHPImage.GetComponent<Image>().fillAmount = hpCurrent;
    }


    //  몬스터 체력 초기화(stage에 따른 체력 변화)
    void MonsterHPInit()
    {
        int HP = 100 * RelicsManager.Instance.stage;// * stage;
        RelicsManager.Instance.monsterTotalHP = RelicsManager.Instance.monsterHP = HP;
    }


    //  유적 단계 변화
    //  유적 파괴시 단계 증가
    void MonsterStageUp()
    {
        RelicsManager.Instance.stage += 1;

        if (RelicsManager.Instance.stage % 10 == 0)
        {
            //Debug.Log(" Get Relics : " + "stage: " + stage + "----- stage%20 : " + stage % 20);
            controlOfRelics.GetRelicsPiece(RelicsManager.Instance.stage);
        }
    }

    //  유적 단계 변화
    //  유적 파괴시 단계 증가
    void MonsterStageDown()
    {
        RelicsManager.Instance.stage -= 1;
    }

    //  몬스터 변경
    //  스테이지 확인 후 변경
    void MonsterChange()
    {
        string monsterImagePath = string.Format("Images/Monster/{0}", RelicsManager.Instance.stage);
        RelicsManager.Instance.monsterImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(monsterImagePath);
    }


    //  유적지 단계 변경
    void MonsterStage()
    {
        RelicsManager.Instance.stageText.GetComponent<Text>().text = RelicsManager.Instance.stage.ToString();
    }
}
