using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundSurvived : MonoBehaviour
{
    public TMP_Text roundsText;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }
IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);

        while (round < PlayerStats.rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }
}
