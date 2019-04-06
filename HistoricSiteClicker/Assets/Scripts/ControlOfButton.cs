using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlOfButton : MonoBehaviour
{
    public GameObject[] gamePanel;
    int select;
    int temp;

    public void SelectPanel(int select)
    {
        this.select = select;
        Change();
    }
    
    void Change()
    {
        gamePanel[temp].SetActive(false);
        gamePanel[select].SetActive(true);

        this.temp = this.select;
    }
}
