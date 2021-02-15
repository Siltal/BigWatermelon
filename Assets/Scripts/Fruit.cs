using UnityEngine;


public class Fruit : MonoBehaviour
{
    public static bool half = false;
    public static Game game;
    public int addScore;
    public GameObject NextPrefab;


    private void Awake()
    {
        game = GameObject.FindWithTag("GameController").GetComponent<Game>();
    }

    private void Start()
    {

    }

    public void SetSimulated(bool b)
    {
        GetComponent<Rigidbody2D>().simulated = b;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        game.FruitCombine(this, other);
        
    }
}