using System.Collections;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    GameManager gameManager;
    DifficultyManager difficultyManager;
    private int Score;

    private void Awake()
    {
        difficultyManager = FindAnyObjectByType<DifficultyManager>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Start()
    {
        StartCoroutine(BombDisappearRoutine());
    }

    IEnumerator BombDisappearRoutine()
    {
        yield return new WaitForSeconds(3f);
        LevelSelect();
        Destroy(gameObject);
    }

    private void LevelSelect()
    {

        Score = PlayerPrefs.GetInt("Score", 0);
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

    private void OnMouseDown()
    {
        gameManager.HealthSystem();
    }

}
