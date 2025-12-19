using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{

    private Label scoreLabel;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        scoreLabel = root.Q<Label>("ScoreText");
    }

    public void AddScore(int score)
    {
        scoreLabel.text = score.ToString();
    }

}
