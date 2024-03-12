using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construção : MonoBehaviour
{
    private Char Char;
    private bool podeAbrir;
    public GameObject telaConstrução;

    [SerializeField]
    public float distance;
    public TextoQuest t;
    public string txt;
    private float distanceInicial = 1.5f;
    
    private void Start()
    {
        Char = FindObjectOfType<Char>();
    }

    void Update()
    {

        if (Vector2.Distance(Char.transform.position, transform.position) < distance)
        {
            t.desc.text = txt;

        }

        if (Vector2.Distance(Char.transform.position, transform.position) < distance && Input.GetKeyDown(KeyCode.E) && !telaConstrução.activeSelf && podeAbrir)
        {
            distance = 0;
            telaConstrução.SetActive(true);
            Char.DisableControls();
        }
     
    }

    public void SetPodeAbrirTrue()
    {
        podeAbrir = true;
    }
    

}
