using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "      GameOver  \nScore: " + GameManager.Instance.Score.ToString();
    }
}
