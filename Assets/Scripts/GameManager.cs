using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    GameObject Spawnedball;
    public float Ballforce;
    int score = 0;
    [SerializeField] private UIManager UIManager;
    public DifficultyManager difficultyManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        QualitySettings.vSyncCount = 0; // disable VSync
        Application.targetFrameRate = 60;

    }

    void Start()
    {

        difficultyManager.LevelOne();
    }

    public GameObject SpawnBall()
    {
        Spawnedball = Instantiate(ballPrefab, new Vector3(Random.Range(-1.3f, 1.3f), Random.Range(0f, 2.5f), 0), Quaternion.identity);
        return Spawnedball;
        
    }

    public void ScoreSystem()
    {
        score++;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        UIManager.AddScore(score);

    }
}
