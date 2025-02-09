using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    [SerializeField]
    PlayerController playerRef;
    [SerializeField]
    private TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + playerRef.score;
    }
}
