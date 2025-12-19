using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField]
   public  GameManager gameManager;
    private GameObject SpawnedBall;
    private Rigidbody2D Ballrb;
    float BallForce = 10f;
    float CurrectScaleOfBall = 1.3f;

    public void LevelOne()
    {
        gameManager.SpawnBall();
    }

    public void LevelTwo() 
    {
        
       
        SpawnedBall = gameManager.SpawnBall();
        
        Ballrb = SpawnedBall.GetComponent<Rigidbody2D>();
        int randomnumber = UnityEngine.Random.Range(-2, 1);
        //Debug.Log(randomnumber);
        if (randomnumber <= 0)
        {
            Ballrb.AddForce(new Vector2(-BallForce, 0), ForceMode2D.Impulse);
        }
        else if (randomnumber > 0)
        {
            Ballrb.AddForce(new Vector2(BallForce, 0), ForceMode2D.Impulse);


        }
    }
    
    public void LevelThree()
    {
        CurrectScaleOfBall = CurrectScaleOfBall - 0.03f;
        float BallNewSize = Mathf.Max(CurrectScaleOfBall, 1f);
        BallForce = BallForce + 1.5f;
        float BallForceL3 = Mathf.Clamp(BallForce, 10f, 15f);
        SpawnedBall = gameManager.SpawnBall();
        SpawnedBall.transform.localScale = Vector2.one * BallNewSize;
        Ballrb = SpawnedBall.GetComponent<Rigidbody2D>();
        int randomnumber = UnityEngine.Random.Range(-2, 1);
        //Debug.Log(randomnumber);
        if (randomnumber <= 0)
        {
            Ballrb.AddForce(new Vector2(-BallForceL3, 0), ForceMode2D.Impulse);
        }
        else if (randomnumber > 0)
        {
            Ballrb.AddForce(new Vector2(BallForceL3, 0), ForceMode2D.Impulse);


        }

    }

    public void LevelFour()
    {

        SpawnedBall = gameManager.SpawnBall();
        SpawnedBall.transform.localScale = Vector2.one;
        Ballrb = SpawnedBall.GetComponent<Rigidbody2D>();
        Ballrb.bodyType = RigidbodyType2D.Kinematic;

    }

}
