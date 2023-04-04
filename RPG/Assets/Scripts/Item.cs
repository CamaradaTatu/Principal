using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public int id;
    public int count;
    public int mutiplicador;
    public Sprite imagemDoItem;

    private Char Char;
    private Inventory inv;
    
    [SerializeField]
    public float distance;

    // Use this for initialization
    void Start()
    {
        Char = FindObjectOfType<Char>();
        inv = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Char.transform.position, transform.position) < distance)
        {            
            
            inv.addItem(id, count, mutiplicador,imagemDoItem);
            Destroy(gameObject);            
        }
    }
}
