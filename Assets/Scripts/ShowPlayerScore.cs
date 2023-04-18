using UnityEngine;

public class ShowPlayerScore : MonoBehaviour
{
    [SerializeField] private PlayerRun player;
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
    
    private void ShowNewPlayerScore()
    {
        print(_playerScore);
    }
    
}
