using UnityEngine;

public class DestroyCactuses : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D colliderToEnter)
   {
      if (colliderToEnter.gameObject.TryGetComponent(out CactusMove cactusMove))
      {
         colliderToEnter.gameObject.SetActive(false);
      }
   }
}
