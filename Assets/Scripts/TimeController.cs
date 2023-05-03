using UnityEngine;
using Zenject;

public class TimeController : MonoBehaviour
{
   [Inject] private PlayerRun _playerRun;
   private const float DefaultTimeScale = 1;
   private bool _isPlayerDie = false;
   private void Awake()
   {
    
      ChangeTimeSpeed(false);
   }

   private void OnEnable()
   {
      _playerRun.PlayerDie += PlayerDie;
   }

   private void OnDisable()
   {
      _playerRun.PlayerDie -= PlayerDie;
   }

   public void ChangePauseState()
   {
      if (Time.timeScale == 0)
      {
         ChangeTimeSpeed(false);
         return;
      }
      ChangeTimeSpeed(true);
   }
   
   private void ChangeTimeSpeed(bool pauseGame)
   {
      if (_isPlayerDie)
      {
         Time.timeScale = 0;
         return;
      }
      if (pauseGame)
      {
         Time.timeScale = 0;
         return;
      }
      Time.timeScale = DefaultTimeScale;
   }

   private void PlayerDie()
   {
      _isPlayerDie = true;
      ChangeTimeSpeed(true);
   }
}
