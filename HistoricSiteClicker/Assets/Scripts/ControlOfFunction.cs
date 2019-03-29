using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  2개의 버튼을 관리하기 위한 스크립트
//  first는 가장 먼저 보여줄 것
//  second는 나주에 보여줄 것

// 스크립트 수정이 필요함
public class ControlOfFunction : MonoBehaviour {

    public GameObject firstObject;
    public GameObject SecondObject;

    

    // Use this for initialization
    void Start()
    {
        firstObject.SetActive(true);
        SecondObject.SetActive(false);
    }

    public void OnFirstObject()
    {
        firstObject.SetActive(true);
        SecondObject.SetActive(false);
    }
    public void OnSecondObject()
    {
        SecondObject.SetActive(true);
        firstObject.SetActive(false);
    }
}
