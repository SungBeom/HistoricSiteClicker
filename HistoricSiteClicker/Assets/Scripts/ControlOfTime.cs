using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlOfTime : MonoBehaviour
{
    public Text playTimeText;
    public Text turnEndTimeText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PlayTime");
        StartCoroutine("TurnEndTime");
    }

    IEnumerator PlayTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);     //  1초후 공격
            float time;
            float.TryParse(playTimeText.text, out time);
            time -= 1.0f;

            playTimeText.text = string.Format("{0}", time);
        }
    }
    public IEnumerator TurnEndTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            float time;
            float.TryParse(turnEndTimeText.text, out time);
            time -= 1.0f;
            if (time <= 0)
            {
                //ControlOfMonster.Instance.TurnTimeOut();
                time = 30.0f;
            }
            turnEndTimeText.text = string.Format("{0}", time);   
        }
    }
}
