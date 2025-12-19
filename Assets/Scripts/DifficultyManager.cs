using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField]
    public bool isballdestryed = false;
   public  GameManager gameManager;

    public void LevelOne()
    {
        gameManager.Ballforce = gameManager.Ballforce + 0.2f;
        gameManager.SpawnBall();
    }
}
