using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    GameObject Spawnedball;
    Rigidbody2D Ballrb;
    int randomnumber;
    public float Ballforce;
    int score = 0;
    [SerializeField] private UIManager UIManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        QualitySettings.vSyncCount = 0; // disable VSync
        Application.targetFrameRate = 60;

    }

    void Start()
    {
        
        SpawnBall();
    }

    public void SpawnBall()
    {
        Spawnedball = Instantiate(ballPrefab, new Vector3(Random.Range(-1.3f, 1.3f), Random.Range(0f, 2.5f), 0), Quaternion.identity);
        Ballrb= Spawnedball.GetComponent<Rigidbody2D>();
        randomnumber = Random.Range(-2, 1);
        Debug.Log(randomnumber);
        if(randomnumber <= 0)
        {
            Ballrb.AddForce(new Vector2(-Ballforce,0), ForceMode2D.Impulse);
        }
        else if(randomnumber > 0) 
        {
            Ballrb.AddForce(new Vector2(Ballforce, 0), ForceMode2D.Impulse);
            
            
        }
        
    }

    public void ScoreSystem()
    {
        score++;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        UIManager.AddScore(score);

    }
}
