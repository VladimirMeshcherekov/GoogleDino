using UnityEngine;

public class TimeController : MonoBehaviour
{
   [SerializeField] private PlayerRun playerRun;
   private float _defaultTimeScale;
   private bool _isPlayerDie = false;
   private void Awake()
   {
      _defaultTimeScale = Time.timeScale;
   }

   private void OnEnable()
   {
      playerRun.PlayerDie += PlayerDie;
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
      Time.timeScale = _defaultTimeScale;
   }

   private void PlayerDie()
   {
      _isPlayerDie = true;
      ChangeTimeSpeed(true);
   }
}
