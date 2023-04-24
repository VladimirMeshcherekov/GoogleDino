using UnityEngine;
using Zenject;

public class ShowGameOverElements : MonoBehaviour
{
   [Inject] private PlayerRun player;
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
