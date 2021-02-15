using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static Score ScoreText;
    public int Overtime = 0;
    public Game game;


    private void Awake()
    {
        ScoreText = GameObject.FindWithTag("Score").GetComponent<Score>();
        game = GameObject.FindWithTag("GameController").GetComponent<Game>();
    }


    void Start()
    {
        Overtime = 0;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Overtime = Overtime + 1;
        Debug.Log("  ----------" + Overtime);

        if (Overtime == 80)
        {
            foreach (Transform child in GameObject.FindWithTag("Respawn").transform)
            {
                Destroy(child.gameObject);
            }

            ScoreText.reset();
            Overtime = 0;
            game.SetVoidContainer(true);
        }
    }
}