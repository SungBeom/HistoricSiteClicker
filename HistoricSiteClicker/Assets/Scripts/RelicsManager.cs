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
        StartCoroutine("TurnEndTime");
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
            yield return new WaitForSeconds(1.0f);     //  1초후 공격
            float playTime;
            float.TryParse(playTimeText.text, out playTime);
            playTime -= 1.0f;
            playTimeText.text = string.Format("{0}", playTime);
            
            //  종료 처리
        }
    }
    IEnumerator TurnEndTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            float.TryParse(turnEndTimeText.text, out endOfTurnTime);
            endOfTurnTime -= 1.0f;
            if (endOfTurnTime <= 0)
            {
                //ControlOfMonster.Instance.TurnTimeOut();
                if(relicStage > 0)
                    ControlOfMonster.Instance.TimeOut();
                endOfTurnTime = endOfTimeDefalut;
            }
            turnEndTimeText.text = string.Format("{0}", endOfTurnTime);
        }
    }


    // ========== ========== ========== ==========
    // Monster Control
    public int monsterHP;
    public int relicStage;

    // ========== ========== ========== ==========
    // Hero Control
    public int heroDamage;

    // ========== ========== ========== ==========
    // Colleague Control
    public int[] colleagueDamage;

}
