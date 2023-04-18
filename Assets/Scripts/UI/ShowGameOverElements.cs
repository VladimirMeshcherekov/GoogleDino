using UnityEngine;

public class ShowGameOverElements : MonoBehaviour
{
   [SerializeField] private PlayerRun player;
   [SerializeField] private GameObject objectToShow;

   private void OnEnable()
   {
      player.PlayerDie += ShowElements;
   }
   
   private void OnDisable()
   {
      player.PlayerDie -= ShowElements;
   }

   private void ShowElements()
   {
      objectToShow.SetActive(true);
   }
   
}
