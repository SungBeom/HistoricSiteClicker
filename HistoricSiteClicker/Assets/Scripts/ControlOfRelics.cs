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

    GameObject parentObject;
    Transform relicsImage;
    //  차후 저장된 값에 따라  초기화 해야함.
    //public void Start()
    //{
    //}
    void Start()
    {
        parentObject = GameObject.Find("RelicsObject");
        relicsImage = null;
    }

    //  유물 획득
    //  동기화에 대한 설정이 필요하다.
    public void GetRelics(int stage)
    {
        string path = "Images/Relics/relics0";      //string.Format(, stage / 10);   "Images/Monster/{0}"
        int relicsFirst = stage / 101;
        int relicsSecond = (stage / 20) % 5;

        string relicsName = string.Format("RelicsAll/RelicsAllScrollView/Viewport/Content/RelicsAllShowObject/RelicsAllStage{0}/RelicsAllImageObject{0}/RelicsImage{0}_{1}", relicsFirst, relicsSecond);


        //  Debug.Log(relicsName);
        //  stage에 따른 image호출(특정 스테이지)
        //  Debug.Log(relicsFirst);
        //  Debug.Log(relicsSecond - 1);
        //  Debug.Log(relicsName);

        relicsImage = parentObject.transform.Find(relicsName);
        Debug.Log(path);
        relicsImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
        //try
        //{
        //}
        //catch(Exception e)
        //{
        //    //Debug.Log(relicsFirst);
        //    //Debug.Log(relicsSecond - 1);
        //    Debug.Log(relicsName);
        //    Debug.Log("Relics Error - " + e.Message);
        //}

    }
    //  유물 결합
    public void CombinationRelics()
    {
        //EventSystem.current.currentSelectedGameObject.name;
        
    }
    //  유물 결합을 통한 데미지 증가
}
