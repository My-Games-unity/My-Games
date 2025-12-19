using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 touchWorldPos;
    Vector2 touchPos2D;
    GameManager gameManager;
    DifficultyManager difficultyManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        difficultyManager = FindAnyObjectByType<DifficultyManager>();
    }


    /* void Update()
     {

         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
         {
             touchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
             touchPos2D = new Vector2(touchWorldPos.x, touchWorldPos.y);

             Collider2D hit = Physics2D.OverlapPoint(touchPos2D, LayerMask.GetMask("Ball"));
             if (hit != null && hit.transform == transform)
             {

                 Destroytheball();

             }

             else 
             {
                 Debug.Log("GPA touched");

             }

         }
     }*/

    private void OnMouseDown()
    {
        Destroytheball();
    }

    public void Destroytheball() // Destroy ball 
    {
        
        Destroy(gameObject);
        gameManager.ScoreSystem();
        difficultyManager.LevelOne();


    }

   



}


