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
        List<GameObject> enemiesAbleToSpawn = pool.FindAll(p => p.activeSelf == false);
        result = enemiesAbleToSpawn[Random.Range(0, enemiesAbleToSpawn.Count)];
        return result != null;
    }
}