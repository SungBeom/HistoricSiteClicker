using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

//  유물에 관한 스크립트
public class ControlOfRelics : MonoBehaviour {
    public Image[] artifactImg;
    
    void Start()
    {
        // todo: 통합후 메인 매니저에 있는 데이터 사용
        for (int i = 0; i < artifactImg.Length; i++)
            if (!RelicsManager.Instance.activeArtifact[i])
                artifactImg[i].enabled = false;
    }

    //  유물 획득
    public void GetRelicsPiece(int stage)
    {
        //  Debug.Log(stage + ": ......" +  stage / 10);
        //  todo:manager통합후 조각 획득 부분 변경
        if ((stage % 10) == 0 && !RelicsManager.Instance.artifactGetPiece[(stage / 10) -1])
        {
            RelicsManager.Instance.artifactGetPiece[(stage / 10) -1] = true;
            RelicsManager.Instance.artifactCount++;
        }
    }
}
