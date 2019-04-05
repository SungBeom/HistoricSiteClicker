﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;
public class ControlOfHeroUpgrade : MonoBehaviour {

    public GameObject[] upBtn;
    public GameObject[] upText;
    public GameObject moneyText;

    public int selectUpgrade;

    // Use this for initialization
    void Start()
    {
        foreach (GameObject go in upBtn)
            go.GetComponentInChildren<Text>().text = "구매";
    }

    public void OnButtonFunction()
    {
        string currentTag = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        //  태그가 고용이 아닌 경우 업그레이드, 고용인 경우 고용
        if (currentTag != "구매")
        {
            OnUpgrade();
        }
        //  고용을 강화로 변경
        else
        {
            OnBuy();
        }

    }
    void OnBuy()
    {
        string btnName = EventSystem.current.currentSelectedGameObject.name;
        int num = int.Parse(btnName[17].ToString());
        upText[num].GetComponent<Text>().text = "1000";
        EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "강화";
    }
    //  unit upgrade
    //  todo : 업그레이드에 관한 비율은 차후 조정
    void OnUpgrade()
    {
        string btnName = EventSystem.current.currentSelectedGameObject.name;
        int num = int.Parse(btnName[17].ToString());



        if (CheckUpgrade())
        {
            Debug.Log("Upgrade success");
        }
        else
        {
            Debug.Log("Upgrade fail");
        }
    }
    bool CheckUpgrade()
    {
        int money = int.Parse(moneyText.GetComponent<Text>().text);
        int upgradeCost = RelicsManager.Instance.heroUpgradePrice[selectUpgrade];
        if (money >= upgradeCost)
        {
            money = money - upgradeCost;
            RelicsManager.Instance.heroUpgrade[selectUpgrade]++;
            RelicsManager.Instance.heroUpgradePrice[selectUpgrade] = upgradeCost * RelicsManager.Instance.heroUpgrade[selectUpgrade];

            moneyText.GetComponent<Text>().text = money.ToString();
            //upText[num].GetComponent<Text>().text = cost.ToString();
            return true;
        }

        return false;
    }
    //  hero attack damage increase
    void HeroNormalAttackDamageUpgrade()
    {

    }
}
