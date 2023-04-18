using UnityEngine;

public class TimeController : MonoBehaviour
{
   [SerializeField] private PlayerRun playerRun;
   private const float DefaultTimeScale = 1;
   private bool _isPlayerDie = false;
   private void Awake()
   {
    
      ChangeTimeSpeed(false);
   }

   private void OnEnable()
   {
      playerRun.PlayerDie += PlayerDie;
   }

   private void OnDisable()
   {
      playerRun.PlayerDie -= PlayerDie;
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
