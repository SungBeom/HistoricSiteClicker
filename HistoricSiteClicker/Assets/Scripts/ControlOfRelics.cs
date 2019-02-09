using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//  유물에 관한 스크립트
//  1. 유물 획득
//  2. 유물 조합
//  3. 유물 버프
public class ControlOfRelics : MonoBehaviour {
    //public Animator monster;
    //public Animator hero;
    public Image[] relicsImages;

    public void Start()
    {
        relicsImages = new Image[6];
    }

    //  유물 획득
    public void GetRelics(int stage)
    {
        string path = string.Format("Images/Relics/relics{0}", stage / 10);
        relicsImages[stage / 10].sprite = Resources.Load<Sprite>(path);
    }
    //  유물 결합
    public void CombinationRelics()
    {

    }
    //  유물 결합을 통한 데미지 증가
}
