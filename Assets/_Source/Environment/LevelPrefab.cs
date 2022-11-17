using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPrefab : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<GameObject> objects;

    public Transform SpawnPoint => spawnPoint; 

    public void HideSomeObjects()
    {
        for(int i = 0; i < Random.Range(2, transform.childCount); i++)
        {
            objects[Random.Range(0, objects.Count-1)].gameObject.SetActive(false);
        }
    }
}
