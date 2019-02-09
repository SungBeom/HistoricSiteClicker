using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOfHeroAttack : MonoBehaviour {


    public Animator Hero;
    //public Animator Monster;
    //public GameObject monsterHPImage;

    //  기본 공격
    //  todo : skill 공격 추가 여부 확인 및 이를 통한 반영(이벤트 또는 게이지 스킬
    public void HeroAttack()
    {
        NormalAttack();
    }

    void NormalAttack()
    {
        Hero.SetTrigger("NormalAttackTrigger");
    }
}
