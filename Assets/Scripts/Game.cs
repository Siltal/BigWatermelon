using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public static Score ScoreText;
    public List<Fruit> fruitPrefabsList;
    public Transform spawnPoint;
    public GameObject Redline;
    public SoundPlayer soundPlayer;
    public bool VoidContianer = true;
    private Fruit _fruit;
    private double lastTimeStamp;
    


    private void Awake()
    {
        soundPlayer = GameObject.FindWithTag("Sound").GetComponent<SoundPlayer>();
        Application.targetFrameRate = 60;
        ScoreText = GameObject.FindWithTag("Score").GetComponent<Score>();
    }

    private void Start()
    {
        _fruit = FruitSpawn();
    }

    private void Update()
    {
        // if (Application.platform == RuntimePlatform.WindowsEditor ||
        //     Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (new TimeSpan(DateTime.Now.Ticks).TotalMilliseconds-lastTimeStamp<800)
                {
                    return;
                }
                lastTimeStamp=new TimeSpan(DateTime.Now.Ticks).TotalMilliseconds;
                Redline.GetComponent<GameOver>().Overtime = 0;
                if (VoidContianer)
                {
                    _fruit = FruitSpawn();  
                }

                Vector3 dropPos = spawnPoint.transform.position; //新建生成点的transform的位置的副本
                dropPos.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x; //将副本的x改为从屏幕获取转为世界坐标的x
                _fruit.transform.position = dropPos; //将副本的位置给水果实例
                _fruit.SetSimulated(true); //让水果下落
                _fruit = FruitSpawn(); //新生成水果
            }
        }
    }

    private Fruit FruitSpawn()
    {
        var readyfruit = Instantiate(fruitPrefabsList[Random.Range(0, fruitPrefabsList.Count)], spawnPoint.transform);
        readyfruit.SetSimulated(false);
        VoidContianer = false;
        return readyfruit;
    }

    public void SetVoidContainer(bool s)
    {
        VoidContianer = s;
    }

    public void FruitCombine(Fruit self, Collision2D other)
    {
        if (other.gameObject.CompareTag("GameController"))
            soundPlayer.flow_play();
        if (self.NextPrefab == null) return;
        if (self.name != other.gameObject.name) return;
        if (!Fruit.half)
            Fruit.half = true;
        else
        {
            
            
          
                soundPlayer.compose_play();
            
            ScoreText.AddScore(self.addScore);
            Destroy(self.gameObject);
            Destroy(other.gameObject);
            var newPosition = (self.gameObject.transform.position + other.gameObject.transform.position) / 2;
            Instantiate(self.NextPrefab, newPosition, Quaternion.identity, spawnPoint);
            if (self.addScore==1024)
                soundPlayer.beats_play();
            Fruit.half = false;
        }
    }
}