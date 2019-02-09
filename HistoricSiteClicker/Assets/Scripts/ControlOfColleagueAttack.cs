using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//  colleague attack
//  콜리더 충돌이 발생한 경우 몬스터의 HP 감소 ..?
//  꼭 콜리더를 달고 rigidybody를 추가해야하나?
//  그냥 끝에 도달하면 에너지 감소하는 방식으로 변경하자/

public class ControlOfColleagueAttack : MonoBehaviour {
    public GameObject monster;
    //차후에 초를 받을 수 있도록 변경
    void Start()
    {
        StartCoroutine("AttackStart");
        //Debug.Log("Test-coroutine");
    }
    IEnumerator AttackStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ColleagueAttack();
            //Debug.Log("Test");
        }
    }

    void ColleagueAttack()
    {
        int monsterHP = monster.GetComponent<Animator>().GetInteger("MonsterHP");
        int colleagueDamage = gameObject.GetComponent<Animator>().GetInteger("AttackDamage");

        monsterHP -= colleagueDamage;
        monster.GetComponent<Animator>().SetInteger("MonsterHP", monsterHP);
    }
}
