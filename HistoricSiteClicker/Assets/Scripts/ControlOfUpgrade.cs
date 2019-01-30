using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ControlOfUpgrade : MonoBehaviour {

    public GameObject[] upBtn = new GameObject[6];
    public GameObject[] upText = new GameObject[6];
    public GameObject[] gameCharacter = new GameObject[6];
    public GameObject moneyText;

    
	// Use this for initialization
	void Start () {
        foreach(GameObject go in upBtn)
            go.GetComponentInChildren<Text>().text = "고용";
        foreach (GameObject gc in gameCharacter)
            gc.SetActive(false);
    }

    public void OnButtonFunction()
    {
        string currentTag = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        //  태그가 고용이 아닌 경우 업그레이드, 고용인 경우 고용
        if(currentTag != "고용")
        {
            OnUpgrade();
        }
        //  고용을 강화로 변경
        else
        {
            OnEmploy();
        }
       
    }
    void OnEmploy()
    {
        string btnName = EventSystem.current.currentSelectedGameObject.name;
        int num = int.Parse(btnName[6].ToString());
        gameCharacter[num].SetActive(true);
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
}
