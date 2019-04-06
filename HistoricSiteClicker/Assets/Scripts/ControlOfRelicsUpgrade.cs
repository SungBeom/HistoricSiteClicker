using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlOfRelicsUpgrade : MonoBehaviour
{
    public Button[] upBtn;
    public Text[] upText;
    public GameObject moneyText;

    int selectItem;
    public void OnUpgrade(int selectItem)
    {
        this.selectItem = selectItem;

        int money = int.Parse(moneyText.GetComponent<Text>().text);
        int upgradeCost = RelicsManager.Instance.relicsPrice[selectItem];

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
    bool CheckUpgrade(int money, int upgradeCost)
    {
        if (money >= upgradeCost)
        {
            return true;
        }
        return false;

    }
    void Upgrade(int money, int upgradeCost)
    {
        money = money - upgradeCost;
        // 강화 수치 증가
        RelicsManager.Instance.relicsUpgrade[selectItem]++;
        // 강화 비용 증가
        RelicsManager.Instance.inRelicsPrice[selectItem] = upgradeCost * RelicsManager.Instance.relicsPrice[selectItem];
        // 변경된 강화 비용 적용
        switch (selectItem)
        {
            // enhance
            case 0:
                WeakenUpgrade();
                break;
            // weaken
            case 1:
                EhanceUpgrade();
                break;
            default:
                break;
        }
        moneyText.GetComponent<Text>().text = money.ToString();
    }

    /*
     * 유적 강화
     * todo : 차후 수치에 따른 변화 적용
     */
    // ehance : 유적의 영향을 감소, 유닛의 능력 증가
    void EhanceUpgrade()
    {
        RelicsManager.Instance.inRelicsType[selectItem] = RelicsManager.Instance.relicsType[selectItem] * RelicsManager.Instance.relicsUpgrade[selectItem];
    }
    // weaken : 유적을 약화시켜, 유적의 체력 감소
    void WeakenUpgrade()
    {
        RelicsManager.Instance.inRelicsType[selectItem] = RelicsManager.Instance.relicsType[selectItem] * RelicsManager.Instance.relicsUpgrade[selectItem];
    }

}
