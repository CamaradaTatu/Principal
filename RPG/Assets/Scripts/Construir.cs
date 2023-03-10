using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Construir : MonoBehaviour
{
    public Inventory inventory;
    public Item[] items;
    public Animator animation;
    public GameObject fakeButton;

    [Header("Requisitos")]
    public List<int> QuantAtual;
    public List<int> QuantRequerida;
    public List<int> idItem;

    [Header("item a ser melhorado")]
    public int aumento;
    public int idAumento;

    public void Awake()
    {
        items = GameObject.FindObjectsOfType<Item>();
    }


    public bool itensSuficientes()
    {
        bool r = false;
        for (int i = 0; i < QuantRequerida.Count; i++)
        {
            if (QuantAtual[i] >= QuantRequerida[i])
            {
                r = true;
                
            }
            else
            {
                r = false;
                break;
            }
        }
        return r;

    }
    public void consumirItens(int id)
    {
        
        {
            bool t = false;
            for (int i = 0; i < inventory.itemInInv.Count; i++)
            {
                if (inventory.itemInInv[i].id == id)
                {
                    inventory.itemInInv[i].count -= QuantRequerida[i];
                    t = true;
                    break;
                }
            }
            if (t == false)
            {
                print("Item não encontrado!");
            }
        }
    }
    public void ProgressoItens(List<int> itensNecessarios, List<int> idN)
    {
        for (int i = 0; i < inventory.itemInInv.Count; i++)
        {
            int id = inventory.itemInInv[i].id;
            for (int l = 0; l < QuantAtual.Count; l++)
            {
                if (idN[l] == id)
                {
                    QuantAtual[l] = inventory.itemInInv[i].count;
                }
            }
        }
        QuantRequerida = itensNecessarios;
    }
    public void aumentarMutiplicadorDeColeta()
    {
        if (itensSuficientes())
        {
            consumirItens(idAumento);
            for(int i = 0; i< items.Length; i++)
            {
                if(items[i].id == idAumento)
                {
                    items[i].mutiplicador += aumento;
                    Debug.Log("certo");
                    this.gameObject.SetActive(false);
                    fakeButton.SetActive(true);
                }
            }
        }
        else {
            animation.Play("ISFentry");
        }
    }
    public void Update()
    {
        ProgressoItens(QuantRequerida,idItem);
    }

}
