using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class LıvesUI : MonoBehaviour
{
    public Text livesText;
    private void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " KALAN";
    }
}