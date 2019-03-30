using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

//  유물에 관한 스크립트
//  1. 유물 획득
//  2. 유물 조합
//  3. 유물 버프
public class ControlOfRelics : MonoBehaviour {
    public Animator hero;
    public Animator monster;
    public uint[][] currentRelics;

    GameObject parentObject;
    

    int[ , ] relics = new int[15, 11];

    void Start()
    {

        //  유물 위치에 대한 부모 값(유물 조각은 처음에 set active false이다.)
        // 변경해야함.
        parentObject = GameObject.Find("RelicsObject");

        //  유물
        //  유물 조각 획득 여부(0-9) : 0, 1, 2 
        //  유물 활성화 여부(10) : 0, 1
        System.Array.Clear(relics, 0, relics.Length);   //  0으로 초기화 -> test를 위한 초기화 이며, 차후 manager에 추가하여 사용할 예정
    }

    //  유물 획득
    public void GetRelicsPiece(int stage)
    {
        string path = "Images/Relics/relics0";      //string.Format(, stage / 10);   "Images/Monster/{0}"
        int relicsFirst = stage / 101;
        int relicsSecond = (stage / 10) % 10;
        string relicsName = string.Format("RelicsAll/RelicsAllScrollView/Viewport/Content/RelicsAllShowObject/RelicsAllStage{0}/RelicsImage{1}", relicsFirst, relicsSecond);
        Transform relicsPieceImage = parentObject.transform.Find(relicsName);

        ///Debug.Log(path);
        //relicsImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
        relicsPieceImage.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        relics[relicsFirst, relicsSecond] = 1;
    }

    //  유물 결합
    public void CombinationRelicsPiece()
    {
        string name = EventSystem.current.currentSelectedGameObject.transform.parent.name;
        string relicsName = string.Format("RelicsCurrent/RelicsCurrentImageObject/RelicsImage{0}", name.Substring(name.Length-1));
        Transform relicsImage = parentObject.transform.Find(relicsName);

        bool check = true;
        int relicsNum;
        int.TryParse(name.Substring(name.Length - 1), out relicsNum);

        //Debug.Log(relicsNum);
        //Debug.Log(relics.GetLength(1));
        for (int i =0; i< relics.GetLength(1) -1; i++)
        {
            if(relics[relicsNum, i] != 1)
            {
                check = false;
            }
        }

        //
        if(check)
        {
            relicsImage.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
            relics[relicsNum, 10] = 1;
        }
        else
        {
            Debug.Log("Not combination");
        }

    }
    //  유물 결합을 통한 데미지 증가
}
