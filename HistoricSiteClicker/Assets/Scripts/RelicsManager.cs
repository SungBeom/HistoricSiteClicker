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
    public int heroDamage;

    // ========== ========== ========== ==========
    // Colleague Control
    // todo : colleagueDamage 부분은 manager 통합후 변경되야함 + ControlOfColleagueAttack내부 코드도 변경되야함 ...흠 기본공격으로 초기화 해서 받아온다?
    // public int colleagueNum;
    public int[] colleagueDamage;
    //public int[] 



    // ========== ========== ========== ==========
    // Control Relic
    // - Control of Reclis 스크립트에서 해야할것
    //    -> start했을때 유물 현황에 따른 유물 변화
    //    -> stage 변화에 따른 유물 변화
    //    -> 유물 활성에 따른 변화
    // - GameManager에서 Relic 데이터를 들고온다 가정
    // - 유물 초기화에 대한 알고리즘 구현 필요함(유물이 추가된다고 가정하면, 초기화 하는데 많은 시간이 걸림)

}
