using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score.ToString();
    }
}
