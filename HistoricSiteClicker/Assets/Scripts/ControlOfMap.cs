using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlOfMap : MonoBehaviour
{
    public GameObject map;
    public GameObject[] drawbtn = new GameObject[6];
    public SpriteRenderer[] drawSpace = new SpriteRenderer[6];
    
    // Use this for initialization
    void Start()
    {
        map.SetActive(false);
    }


    //  map open
    public void OnMap()
    {
        map.SetActive(true);
    }
    //  map close
    public void CloseMap()
    {
        map.SetActive(false);
    }

    //  map change
    //  맵에서 특정 위치 확인
    //  이를 통해 맵 변경
    public void ChangeMap()
    {
        string mapPos = EventSystem.current.currentSelectedGameObject.name;
        string mapType ="0";
        string path;

        //  todo : 연산
        switch (mapPos)
        {
            case "SitesButton0":                mapType = "0";                break;
            case "SitesButton1":                mapType = "1";                break;
            case "SitesButton2":                mapType = "2";                break;
            case "SitesButton3":                mapType = "3";                break;
            case "SitesButton4":                mapType = "4";                break;
            case "SitesButton5":                mapType = "5";                break;
        }

        path = string.Format("Images/GameMap/Textures/Map{0}/", mapType);

        //  Debug.Log(path + "A.png");
        //  todo : 불필요한 연산 삭제.
        drawSpace[0].sprite = Resources.Load<Sprite>(path + "A");
        drawSpace[1].sprite = Resources.Load<Sprite>(path + "B");
        drawSpace[2].sprite = Resources.Load<Sprite>(path + "C");
        drawSpace[3].sprite = Resources.Load<Sprite>(path + "D");
        drawSpace[4].sprite = Resources.Load<Sprite>(path + "E");
        drawSpace[5].sprite = Resources.Load<Sprite>(path + "F");

        CloseMap();
    }
}
