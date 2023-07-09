using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectPrefab;
    private Transform mcTransform;

    private void Start()
    {
        mcTransform = FindObjectOfType<Char>().transform;
    }

    public void SpawnarObjeto()
    {
        Instantiate(objectPrefab, mcTransform.position, Quaternion.identity);
    }
}
