using UnityEngine;
using TMPro;
using Zenject;

public class ShowPlayerScore : MonoBehaviour
{
    [Inject] private PlayerRun player;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private string textBeforeScore;
    private int _playerScore;
    private void OnEnable()
    {
        player.PlayerAddScore += ChangePlayerScore;
    }

    private void OnDisable()
    {
        player.PlayerAddScore -= ChangePlayerScore;
    }

    private void ChangePlayerScore()
    {
        _playerScore++;
        ShowNewPlayerScore();
    }

    private void Start()
    {
        ShowNewPlayerScore();
    }

    private void ShowNewPlayerScore()
    {
        scoreText.text = textBeforeScore + _playerScore;
    }
    
}
