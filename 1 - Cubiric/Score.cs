using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreMetni;

    // Update is called once per frame
    void Update()
    {
        scoreMetni.text = player.position.z.ToString("0");
    }
}
