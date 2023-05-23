using TMPro;
using UnityEditor;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public void SetScoreText(string scoreText)
    {
        this.scoreText.text = scoreText;
    }
}
