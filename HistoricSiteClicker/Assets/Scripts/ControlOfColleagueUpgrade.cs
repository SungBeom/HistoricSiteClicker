using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlOfColleagueUpgrade : MonoBehaviour {
    public GameObject[] upBtn = new GameObject[6];
    public GameObject[] upText = new GameObject[6];

    public GameObject[] gameCharacter = new GameObject[6];
    public GameObject[] gameCharacterAttack = new GameObject[6];
    public GameObject moneyText;


    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < upBtn.Length; i++)
        {
            upBtn[i].GetComponentInChildren<Text>().text = "고용";
        }
        for (int i = 0; i < gameCharacter.Length; i++)
        {
            gameCharacter[i].SetActive(false);
        }
        for (int i = 0; i < gameCharacterAttack.Length; i++)
        {
            gameCharacterAttack[i].SetActive(false);
        }
    }

    public void OnButtonFunction()
    {
        string currentTag = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        //  태그가 고용이 아닌 경우 업그레이드, 고용인 경우 고용
        if (currentTag != "고용")
        {
            OnUpgrade();
        }
        //  고용을 강화로 변경
        else
        {
            OnEmploy();
        }
    }
    //  고용
    //  고용시 변경사항 변경
    //  케릭터, 공격 활성화, 버튼 text변경, 비용 text변경
    void OnEmploy()
    {
        string btnName = EventSystem.current.currentSelectedGameObject.name;
        int num = int.Parse(btnName[6].ToString());

        //  
        gameCharacter[num].SetActive(true);
        gameCharacterAttack[num].SetActive(true);

        upText[num].GetComponent<Text>().text = "1000";

        EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "강화";
    }
    //  unit upgrade
    //  todo : 업그레이드에 관한 비율은 차후 조정
    void OnUpgrade()
    {
        string btnName = EventSystem.current.currentSelectedGameObject.name;
        int num = int.Parse(btnName[6].ToString());

        int cost = int.Parse(upText[num].GetComponent<Text>().text);
        int money = int.Parse(moneyText.GetComponent<Text>().text);

        if (money >= cost)
        {
            ColleagueDamageUp(num);
            money = money - cost;
            cost = cost + cost * (num + 1);

            moneyText.GetComponent<Text>().text = money.ToString();
            upText[num].GetComponent<Text>().text = cost.ToString();
        }
        else
        {
            Debug.Log("Upgrade fail");
        }

    }
    //  character damage up
    void ColleagueDamageUp(int characterNum)
    {
        int damage = gameCharacterAttack[characterNum].GetComponent<Animator>().GetInteger("AttackDamage");
        //  damage 변경 공식 추가
        damage = (int)(damage * 1.5f);
        gameCharacterAttack[characterNum].GetComponent<Animator>().SetInteger("AttackDamage", damage);
    }
}
