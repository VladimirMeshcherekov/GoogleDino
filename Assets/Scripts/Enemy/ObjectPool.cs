using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectContainer;
    [SerializeField] private int containerCapacity;
    private readonly System.Random _random = new System.Random();
    private List<GameObject> pool = new List<GameObject>();

    protected void Initialize(GameObject[] prefab)
    {
        for (int i = 0; i < containerCapacity; i++) 
        { 
            GameObject spawned = Instantiate(prefab[Random.Range(0, prefab.Length)], objectContainer.transform); 
            spawned.SetActive(false);
            pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    { 
     
        int randomElement = Random.Range(0, containerCapacity);
    
        while (!pool[randomElement].activeSelf == false)
        {   
          
            randomElement = Random.Range(0, containerCapacity);
        }
       
        result = pool[randomElement];  //(p => p.activeSelf == false);
        return result != null;  
    }
}
