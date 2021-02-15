using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score=0;
    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }
    private void Update()

    {
        scoreText.text = "Score: "+score;
    }

    public void  AddScore(int s)
    {
        score += s;
    }

    public void reset()
    {
        score = 0;
    }
}