using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlOfAttack : MonoBehaviour {
    //  기본 공격
    //  todo : 기본 공격력 적용
    //  todo : 기본 공격시 보스 체력 감소
    public void NormalAttack()
    {
        GetComponent<Animator>().SetTrigger("NormalAttackTrigger");
    }
}
