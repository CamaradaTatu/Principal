using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Construir : MonoBehaviour
{
    public Inventory inventory;
    public Item[] items;
    public Animator animation;
    public GameObject fakeButton;
    private Char pessoa;
    public UnityEvent onConstruction;

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
        pessoa = GameObject.FindObjectOfType<Char>();
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
                animation.Play("ISFentry");
                pessoa.audioManager.PlayAudio(pessoa.ISF);
                r = false;
                break;
            }
        }
        return r;

    }
    public void consumirItens(List <int> id)
    {
        
        {
            bool t = false;
            for (int i = 0; i < inventory.itemInInv.Count; i++)
            {
                int idA = inventory.itemInInv[i].id;
                for(int l = 0; l < QuantAtual.Count; l++)
                {
                    if (idA == id[l])
                    {
                        inventory.itemInInv[i].count -= QuantRequerida[l];
                        t = true;
                        break;
                    }
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
    public bool podeConstruir()
    {
        bool v = false;
        if (itensSuficientes())
        {
            consumirItens(idItem);
            v = true;

        }
        else
        {
            v = false;
        }
        return v;
    }
    public void aumentarMutiplicadorDeColeta()
    {

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
    public void Update()
    {
        ProgressoItens(QuantRequerida,idItem);
    }


    public void GastarConstruir()
    {
        if (podeConstruir())
        {
            Debug.Log("proximo");
            pessoa.audioManager.PlayAudio(pessoa.Construído);
            onConstruction.Invoke();
        }
        else
        {
            Debug.Log("ISF");
        }
    }

  
}
