using UnityEngine;

public class Ball : MonoBehaviour
{
   
    GameManager gameManager;
    DifficultyManager difficultyManager;
    private int Score;
   AudioSource BallTapSFX;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        difficultyManager = FindAnyObjectByType<DifficultyManager>();
        BallTapSFX = GameObject.FindGameObjectWithTag("Ball Tap SFX").GetComponent<AudioSource>();

    }

    private void OnMouseDown()
    {
        Destroytheball();
    }

    public void Destroytheball() // Destroy ball 
    {
        
        Destroy(gameObject);
        gameManager.ScoreSystem();
        LevelSelect();

    }

    private void LevelSelect()
    {
        Score = PlayerPrefs.GetInt("Score",0);
        if (Score <= 10)
        {
            difficultyManager.LevelOne();
        }

        if (Score > 10 && Score <= 20) 
        { 
         
            difficultyManager.LevelTwo();
        
        }

        if (Score > 20 && Score <= 35)
        {

            difficultyManager.LevelThree();

        }

        if (Score > 35 && Score <= 70)
        {

            difficultyManager.LevelFour();

        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallTapSFX.Play();
    }





}


