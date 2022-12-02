using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI textScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateTextScore();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTextScore();
    }

    void UpdateTextScore()
    {
        textScore.text = $"${score.ToString()}";
    }
}
