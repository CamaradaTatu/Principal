﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{
    private Char Char;
    public float distance;
    public string cena;

    

    private void Start()
    {
        Char = FindObjectOfType<Char>();
        
    }
    //Carrega uma cena a partir do chamado da função e passagem do nome da cena como parâmetro

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Vector2.Distance(Char.transform.position, transform.position) < distance && Input.GetKeyDown(KeyCode.E) && Char.scene == "Dentro")
        {
            Char.trocarAnimadores();
            Char.scene = "Organismo";
        }
        else if (Input.GetKeyDown(KeyCode.E) && Char.scene == "Organismo")
        {
            Char.trocarAnimadores();
            Char.scene = "Dentro";
        }
    }
}
