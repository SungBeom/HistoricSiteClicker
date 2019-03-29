using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlOfColleagueAttack : MonoBehaviour {
    public GameObject monster;
    int colleagueNum;

    // todd : 케릭터 특성에 따른 공격 변화 필요
    void Start()
    {
        StartCoroutine("AttackStart");
        int.TryParse(gameObject.name.Substring(gameObject.name.Length - 1), out colleagueNum);
        //Debug.Log("Test-coroutine-" + gameObject.name);
    }

    //  공격 코루틴
    IEnumerator AttackStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);     //  1초후 공격
            ControlOfMonster.Instance.BeAttacked(ColleagueAttack());
        }
    }
    //  동료들의 공격
    int ColleagueAttack()
    {
        //int colleagueDamage = gameObject.GetComponent<Animator>().GetInteger("AttackDamage");
        int colleagueDamage = RelicsManager.Instance.colleagueDamage[colleagueNum];
        return colleagueDamage;
    }
}
