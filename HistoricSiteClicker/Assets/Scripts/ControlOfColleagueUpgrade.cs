using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlOfColleagueUpgrade : MonoBehaviour {
    public GameObject[] upBtn;
    public Text[] upText;

    // 차후 moneyText가 아닌 manager에서 가져와서 사용하는 방식으로 적용
    public GameObject moneyText;


    // Use this for initialization
    //void Start()
    //{
    //    for(int i = 0; i < upBtn.Length; i++)
    //    {
    //        upBtn[i].GetComponentInChildren<Text>().text = "강화";
    //        upText[i].GetComponent<Text>().text = "1000";
    //    }
    //    
    //}
    public void Test()
    {

    }

    public void ColleagueUpgrade(int selectColleague)
    {
        long cost = RelicsManager.Instance.colleagueUpgradePrice[selectColleague];
        long money = long.Parse(moneyText.GetComponent<Text>().text);

        if (money >= cost)
        {
            //  강화 횟수 증가
            RelicsManager.Instance.colleagueUpgrade[selectColleague]++;
            RelicsManager.Instance.inColleagueDamage[selectColleague] = RelicsManager.Instance.colleagueDamage[selectColleague] * RelicsManager.Instance.colleagueUpgrade[selectColleague];
            RelicsManager.Instance.colleagueUpgradePrice[selectColleague] = (int)(cost + cost * (selectColleague + 1));
            money = money - cost;

            moneyText.GetComponent<Text>().text = money.ToString();
            //upText[selectColleague].GetComponent<Text>().text = cost.ToString();
        }
        else
        {
            Debug.Log("Upgrade fail");
        }
    }
}
