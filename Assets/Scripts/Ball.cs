using UnityEngine;

public class Ball : MonoBehaviour
{

    GameManager gameManager;
    DifficultyManager difficultyManager;
    private int Score;
    AudioSource BallTapSFX;
    [HideInInspector]
    public Vector2 BallLastPos;
    int TwoXBallSpawnDelay = 50;


    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        difficultyManager = FindAnyObjectByType<DifficultyManager>();
        BallTapSFX = GameObject.Find("Ball Tap SFX").GetComponent<AudioSource>();
        Score = gameManager.score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (BallTapSFX != null)
        {
            BallTapSFX.Play();
        }

    }

    private void OnMouseDown()
    {
        BallLastPos = gameObject.transform.position;

        Destroytheball();
    }

    public void Destroytheball() // Destroy ball 
    {


        LevelSelect();
        TwoXBallSpawn();
        gameManager.CoinReward();
        Destroy(gameObject);

    }

    private void LevelSelect()
    {
        if (Score <= 10)
        {
            difficultyManager.LevelOne();
        }

        else if (Score > 10 && Score <= 20)
        {
            difficultyManager.LevelTwo();
        }

        else if (Score > 20 && Score <= 100)
        {
            difficultyManager.LevelThree();
        }
        else if (Score > 100 && !difficultyManager.is2BallSpawned)
        {
            difficultyManager.LevelFour();
            difficultyManager.LevelFour();
            difficultyManager.HeartBall();
            difficultyManager.is2BallSpawned = true;
        }

        else if (Score > 100 && Score <= 300 && difficultyManager.is2BallSpawned)
        {
            difficultyManager.LevelFour();
        }

        else if (Score > 300 && !difficultyManager.is3BallSpawned)
        {
            difficultyManager.LevelFive();
            difficultyManager.LevelFive();
            difficultyManager.HeartBall();
            difficultyManager.HeartBall();
            difficultyManager.is3BallSpawned = true;
        }


        else if (Score > 300 && Score <= 800 && difficultyManager.is3BallSpawned)
        {
            difficultyManager.LevelFive();
        }

    }

    private void TwoXBallSpawn()
    {
        if (Score.Equals(TwoXBallSpawnDelay))
        {
            difficultyManager.TwoXBall();
            TwoXBallSpawnDelay += 80;
        }
    }

}


