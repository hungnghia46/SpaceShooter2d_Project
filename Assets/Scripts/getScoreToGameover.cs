using UnityEngine;
using TMPro;
public class getScoreToGameover : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverScore;
    private void OnEnable() {
       gameOverScore.text = ScoreManager.Instance.getScore().ToString();
    }
}
