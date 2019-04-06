using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ControlOfHeroUpgrade : MonoBehaviour {
    public Button[] upBtn;
    public Text[] upText;
    public GameObject moneyText;

    int selectUpgradeButton;

    // Use this for initialization
    //void Start()
    //{
    //    //  todo : 강화에 따른 현황 및 해금 변경
    //    //upBtn.text = "구매";
    //}

    //  unit upgrade
    public void OnUpgrade(int selectUpgradeButton)
    {
        this.selectUpgradeButton = selectUpgradeButton;

        int money = int.Parse(moneyText.GetComponent<Text>().text);
        int upgradeCost = RelicsManager.Instance.heroUpgradePrice[selectUpgradeButton];

        if (CheckUpgrade(money, upgradeCost))
        {
            Debug.Log("Upgrade success");
            Upgrade(money, upgradeCost);
        }
        else
        {
            Debug.Log("Upgrade fail");
        }
    }
    //  강화 가능 여부 확인
    bool CheckUpgrade(int money, int upgradeCost)
    {
        if (money >= upgradeCost)
        {
            return true;
        }
        return false;
    }
    //  강화
    void Upgrade(int money, int upgradeCost)
    {
        money = money - upgradeCost;
        // 강화 수치 증가
        RelicsManager.Instance.heroUpgrade[selectUpgradeButton]++;
        // 강화 비용 증가
        RelicsManager.Instance.heroUpgradePrice[selectUpgradeButton] = upgradeCost * RelicsManager.Instance.heroUpgrade[selectUpgradeButton];
        // 변경된 강화 비용 적용
        switch(selectUpgradeButton)
        {
            // heroattacktype[0]
            case 0:
                NormalAttackDamageUpgrade();
                break;
            // heroattacktype[1]
            case 1:
                CriticalProbabilityUpgrade();
                break;
            // heroattacktype[2]
            case 2:
                CriticalDamageUpgrade();
                break;
            default:
                break;
        }
        moneyText.GetComponent<Text>().text = money.ToString();
    }


    /*
     * hero upgrade에 관한 함수
     * - 기본 공격
     * - 크리티컬 발동 확률
     * - 크리티컬 
     * 차후 각 기능별 레벨 디자인이 달라짐으로, 구분 
     */

    //  hero attack damage increase
    void NormalAttackDamageUpgrade()
    {
        RelicsManager.Instance.inHeroAttackType[selectUpgradeButton] = RelicsManager.Instance.heroAttactType[selectUpgradeButton] * RelicsManager.Instance.heroUpgrade[selectUpgradeButton];
    }
    //  hero critical probability increase
    void CriticalProbabilityUpgrade()
    {
        RelicsManager.Instance.inHeroAttackType[selectUpgradeButton] = RelicsManager.Instance.heroAttactType[selectUpgradeButton] * RelicsManager.Instance.heroUpgrade[selectUpgradeButton];
    }
    //  hero critical damage increase
    void CriticalDamageUpgrade()
    {
        RelicsManager.Instance.inHeroAttackType[selectUpgradeButton] = RelicsManager.Instance.heroAttactType[selectUpgradeButton] * RelicsManager.Instance.heroUpgrade[selectUpgradeButton];
    }
}
