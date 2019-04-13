using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
 * hero attack type 
 * 0 : 공력력
 * 1 : 치명타 발동 확률
 * 2 : 치명타 배수 
 */
public class ControlOfHeroAttack : MonoBehaviour
{
    //System.Random random = new System.Random();
    //  기본 공격
    public void HeroAttack()
    {
        int randomValue = Random.Range(0, 100);
        if (randomValue > RelicsManager.Instance.heroAttactType[2])
        {
            Debug.Log("normal attack " + randomValue);
            NormalAttack();
        }
        else
        {
            Debug.Log("critical attack " + randomValue);
            CriticalAttack();
        }
    }
    // 기본 공격 적용
    void NormalAttack()
    {
        int heroDamage = RelicsManager.Instance.inHeroAttackType[0];
        RelicsManager.Instance.heroAnimator.SetTrigger("NormalAttackTrigger"); // todo : 케릭터들이 들고있는 기본 공격 트리거로 변경
        ControlOfMonster.Instance.BeAttacked(heroDamage);
    }
    // 크리티컬 공격
    void CriticalAttack()
    {
        int heroDamage = RelicsManager.Instance.inHeroAttackType[0] * RelicsManager.Instance.inHeroAttackType[2];
        RelicsManager.Instance.heroAnimator.SetTrigger("NormalAttackTrigger"); // todo : 크리티컬 발생시 트리거로 변경
        ControlOfMonster.Instance.BeAttacked(heroDamage);
    }
}
