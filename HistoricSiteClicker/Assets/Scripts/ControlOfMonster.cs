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

    public GameObject monsterImage;
    public GameObject monsterHPImage;
    public Text stageText;
    ControlOfRelics controlOfRelics;

    //  차후 저장된 정보를 통한 초기화에 활용
    int monsterHP;
    int monsterTotalHP;
    int stage;

    void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        controlOfRelics = FindObjectOfType<ControlOfRelics>();

        monsterHP = RelicsManager.Instance.monsterHP;
        monsterTotalHP = RelicsManager.Instance.monsterHP;
        stage = RelicsManager.Instance.relicStage;
        //  todo : 몬스터에 대한 초기화 코드 필요
    }

    //  공격 당함 
    //  todo : 
    public void BeAttacked(int damage)
    {
        monsterHP = monsterHP - damage;
        //  check monster die
        if (monsterHP <= 0)
        {
            MonsterStageUp();
            MonsterHPInit();
            MonsterChange();
            MonsterStage();
            //Debug.Log("boss die and change");
            RelicsManager.Instance.endOfTurnTime = RelicsManager.Instance.endOfTimeDefalut;
            RelicsManager.Instance.playTimeText.text = string.Format("{0}", RelicsManager.Instance.endOfTimeDefalut);
        }
        //  change hp image
        ChangeHPImage(monsterTotalHP, monsterHP);
    }

    //  일정 시간안에 몬스터를 몹잡는 경우
    public void TimeOut()
    {
        MonsterStageDown();
        MonsterHPInit();
        MonsterChange();
        MonsterStage();

        ChangeHPImage(monsterTotalHP, monsterHP);
    }
    // check monster hp
    void ChangeHPImage(int totalHP, int currentHP)
    {
        float currentImage = currentHP / totalHP;
        monsterHPImage.GetComponent<Image>().fillAmount = (float)System.Math.Round(currentImage, 2);
    }


    //  몬스터 체력 초기화(stage에 따른 체력 변화)
    void MonsterHPInit()
    {
        int HP = 100 * stage;// * stage;
        monsterTotalHP = monsterHP = HP;
    }


    //  유적 단계 변화
    //  유적 파괴시 단계 증가
    void MonsterStageUp()
    {
        stage += 1;

        if (stage % 10 == 0)
        {
            //Debug.Log(" Get Relics : " + "stage: " + stage + "----- stage%20 : " + stage % 20);
            controlOfRelics.GetRelicsPiece(stage);
        }
    }

    //  유적 단계 변화
    //  유적 파괴시 단계 증가
    void MonsterStageDown()
    {
        stage -= 1;
    }

    //  몬스터 변경
    //  스테이지 확인 후 변경
    void MonsterChange()
    {
        string monsterImagePath = string.Format("Images/Monster/{0}", stage);
        monsterImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(monsterImagePath);
    }


    //  유적지 단계 변경
    void MonsterStage()
    {
        stageText.GetComponent<Text>().text = stage.ToString();
    }
}
