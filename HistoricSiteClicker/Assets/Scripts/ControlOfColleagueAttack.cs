using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlOfColleagueAttack : MonoBehaviour {
    public GameObject monster;
    ControlOfMonster controlOfMonster;
    //public ControlOfMonster controlOfMonster;
    //차후에 초를 받을 수 있도록 변경
    void Start()
    {
        controlOfMonster = FindObjectOfType<ControlOfMonster>();
        StartCoroutine("AttackStart");
        //Debug.Log("Test-coroutine-" + gameObject.name);
    }

    //  공격 코루틴
    IEnumerator AttackStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);     //  1초후 공격
            controlOfMonster.BeAttacked(ColleagueAttack());
        }
    }
    //  공격
    int ColleagueAttack()
    {
        //int monsterHP = monster.GetComponent<Animator>().GetInteger("MonsterHP");
        int colleagueDamage = gameObject.GetComponent<Animator>().GetInteger("AttackDamage");

        // monsterHP -= colleagueDamage;
        // monster.GetComponent<Animator>().SetInteger("MonsterHP", monsterHP);

        //controlOfMonster.BeAttacked(colleagueDamage);  // 공격시 몬스터의 변화를 위해

        return colleagueDamage;
    }
}
