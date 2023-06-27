using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construção : MonoBehaviour
{
    private Char Char;
    public GameObject telaConstrução;

    [SerializeField]
    public float distance;
    private void Start()
    {
        Char = FindObjectOfType<Char>();
    }

    void Update()
    {
        if (Vector2.Distance(Char.transform.position, transform.position) < distance && Input.GetKeyDown(KeyCode.E) && !telaConstrução.activeSelf)
        {
            telaConstrução.SetActive(true);
            Char.DisableControls();
        }
    }
}
