using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//  임시 매니저
public class RelicsManager : MonoBehaviour
{

    private static RelicsManager instance;
    public static RelicsManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //  hero init
        inHeroAttackType = new int[heroAttactType.Length];
        inHeroUpgradePrice = new int[heroUpgradePrice.Length];
        for (int i =0; i<heroAttactType.Length; i++)
        {
            inHeroAttackType[i] = heroAttactType[i];
            inHeroUpgradePrice[i] = heroUpgradePrice[i];
        }


        //  colleague init
        inColleagueDamage = new int[colleagueDamage.Length];
        inColleagueUpgradePrice = new int[colleagueUpgradePrice.Length];
        for (int i =0; i< colleagueDamage.Length; i++)
        {
            inColleagueDamage[i] = colleagueDamage[i] * colleagueUpgrade[i];
            inColleagueUpgradePrice[i] = colleagueUpgradePrice[i] * colleagueUpgrade[i];
        }

        // relics init
        inRelicsType = new int[relicsType.Length];
        inRelicsPrice = new int[relicsPrice.Length];
        for(int i =0; i< relicsType.Length; i++)
        {
            inRelicsType[i] = relicsType[i] * relicsUpgrade[i];
            inRelicsPrice[i] = relicsPrice[i] * relicsUpgrade[i];
        }


        // timer
        playTimeText.text = string.Format("{0}", RelicsManager.Instance.playTime);
        turnEndTimeText.text = string.Format("{0}", RelicsManager.Instance.endOfTurnTime);
        StartCoroutine("PlayTime");

    }


    // ========== ========== ========== ==========
    // Time Control
    public Text playTimeText;
    public Text turnEndTimeText;

    public float playTime;
    public float endOfTimeDefalut = 15.0f;
    public float endOfTurnTime;

    IEnumerator PlayTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);   
            //  전체 시간
            //  todo : gamemanager에서 가져올 수 있도록 변경해야함.
            float playTime;
            float.TryParse(playTimeText.text, out playTime);
            playTime -= 1.0f;
            playTimeText.text = string.Format("{0}", playTime);

            if(playTime <= 0)
            {
                Debug.Log("end==========================");
            }

            //  턴 시간
            float.TryParse(turnEndTimeText.text, out endOfTurnTime);
            endOfTurnTime -= 1.0f;
            if (endOfTurnTime <= 0)
            {
                //ControlOfMonster.Instance.TurnTimeOut();
                if (stage > 1)
                    ControlOfMonster.Instance.TimeOut();
                endOfTurnTime = endOfTimeDefalut;
            }
            turnEndTimeText.text = string.Format("{0}", endOfTurnTime);

            //  종료 처리
        }
    }


    // ========== ========== ========== ==========
    // Monster Control
    public GameObject monsterImage;
    public GameObject monsterHPImage;
    public Text stageText;

    public int monsterTotalHP;
    public int monsterHP;
    public int stage;  //stage의 경우 차후 gamemanager의 데이터를 들고올것




    // ========== ========== ========== ==========
    // Hero Control
    // - hero animator;
    // - hero damage
    public Animator heroAnimator;
    //  공격력, 치명타확률, 치명타데미지
    public int[] heroAttactType;
    public int[] heroUpgrade;
    public int[] heroUpgradePrice;

    [HideInInspector]
    public int[] inHeroAttackType;
    [HideInInspector]
    public int[] inHeroUpgradePrice;


    // ========== ========== ========== ==========
    // Colleague Control
    // todo : colleagueDamage 부분은 manager 통합후 변경되야함 + ControlOfColleagueAttack내부 코드도 변경되야함 ...흠 기본공격으로 초기화 해서 받아온다?
    // public int colleagueNum; -> test용도

    //  colleagueUpgrade db에서 강화 횟수 들고옴
    //  colleagueDamage main에서 들거옴
    //  colleagueDamage0 영웅의 공격력을 저장함
    //  colleagueDamage1 영웅의 공격력을 저장함
    public int[] colleagueUpgrade;
    public int[] colleagueUpgradePrice;
    public int[] colleagueDamage;

    [HideInInspector]
    public int[] inColleagueDamage;
    [HideInInspector]
    public int[] inColleagueUpgradePrice;
    //public int[] 


    // ========== ========== ========== ==========
    // Control Relic
    // - Control of Reclis 스크립트에서 해야할것
    //    -> start했을때 유물 현황에 따른 유물 변화
    //    -> stage 변화에 따른 유물 변화
    //    -> 유물 활성에 따른 변화

    //  내부 relics 내부 강화 적용
    //  relicsUpgrade는 db에서 강화 횟수 들고옴
    //  0 : ehance
    //  1 : weaken
    //  relicsEhance는 유적의 저주를 약화 시켜 영웅을 강화 시킴
    //  relicsWeaken는 유적의 저주를 약화 시켜 유적을 약화 시킴
    public int[] relicsType;
    public int[] relicsUpgrade;
    public int[] relicsPrice;

    [HideInInspector]
    public int[] inRelicsType;
    [HideInInspector]
    public int[] inRelicsPrice;
}
