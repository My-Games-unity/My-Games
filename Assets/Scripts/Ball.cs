using UnityEngine;

public class Ball : MonoBehaviour
{
   
    GameManager gameManager;
    DifficultyManager difficultyManager;
    private int Score;
    AudioSource BallTapSFX;
    [HideInInspector] 
    public Vector2 BallLastPos;
    

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        difficultyManager = FindAnyObjectByType<DifficultyManager>();
        BallTapSFX = GameObject.Find("Ball Tap SFX").GetComponent<AudioSource>();

    }

    private void OnMouseDown()
    {
       
            BallLastPos = gameObject.transform.position;
            Destroytheball();
       
    }

    public void Destroytheball() // Destroy ball 
    {
       
        gameManager.ScoreSystem();
        LevelSelect();
        Destroy(gameObject);

    }

    private void LevelSelect()
    {
        int BallSpawnChance = Random.Range(10, 100);

        Score = PlayerPrefs.GetInt("Score",0);
        if (Score <= 10)
        {
           
            difficultyManager.LevelOne();
        }

        if (Score > 10 && Score <= 20) 
        {
            if (BallSpawnChance < 30)
            {
                difficultyManager.BombBallSpawn();
            }
            else
            {
                difficultyManager.LevelTwo();
            } 
        
        }

        if (Score > 20 && Score <= 35)
        {

            if (BallSpawnChance < 30)
            {
                difficultyManager.BombBallSpawn();
            }
            else
            {
                difficultyManager.LevelThree();
            }

        }

        if (Score > 35 && Score <= 70)
        {

            if (BallSpawnChance < 30)
            {
                difficultyManager.BombBallSpawn();
            }
            else
            {
                difficultyManager.LevelFour();
            }

        }

        if (Score > 70 && Score <= 100)
        {
            
            difficultyManager.TwoSmallBallSpawn(3, BallLastPos);

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(BallTapSFX != null)
        {
            BallTapSFX.Play();
        }
       
    }





}


