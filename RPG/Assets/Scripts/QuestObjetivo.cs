using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestObjetivo 
{
    public TipoObjetivo tipoObjetivo;
    public Inventory inventory;
    public List<int> QuantAtual;
    public List<int> QuantRequerida;
    public List<int> idItem;
    public KeyCode keyCode;



    public bool completou()
    {
        bool r = false;
        for(int i = 0; i < QuantRequerida.Count; i++)
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
        return  r;
        
    }
     public void ProgressoColeta(List<int> itensNecessarios,List<int> idN)
    {
        for (int i = 0; i < inventory.itemInInv.Count; i++)
        {
            int id = inventory.itemInInv[i].id;
            for (int l = 0; l< QuantAtual.Count; l++)
            {
                if(idN[l] == id)
                {
                    QuantAtual[l] = inventory.itemInInv[i].count;
                }
            }
        }
        QuantRequerida = itensNecessarios;
    }
}
public enum TipoObjetivo
{
    pressioneBotão,
    Colete
}
