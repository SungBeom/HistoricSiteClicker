using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOfHeroAttack : MonoBehaviour
{
    //  기본 공격
    public void HeroAttack()
    {
        NormalAttack();
    }
    // 기본 공격 적용
    void NormalAttack()
    {
        int heroDamage = RelicsManager.Instance.heroDamage;
        RelicsManager.Instance.heroAnimator.SetTrigger("NormalAttackTrigger"); // todo : 케릭터들이 들고있는 기본 공격 트리거로 변경
        ControlOfMonster.Instance.BeAttacked(heroDamage);
    }
}
