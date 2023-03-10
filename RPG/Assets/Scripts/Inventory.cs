using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class item
{
    public string name;
    public string description;
    public enum Type
    {
        Arma,
        Armadura,
        Consumivel,
        Material,
        Chave
    }
    public Type tipo;
    public int value;
}

[System.Serializable]
public class itemInInv
{
    public int id;
    public int count;
    public int mutiplicador;
}

public class Inventory : MonoBehaviour
{

    public List<item> ItemsDB = new List<item>();

    [Header("Player")]
    public List<itemInInv> itemInInv = new List<itemInInv>();

    [Header("Canvas")]
    public GameObject invScene;
    public Text itens;
    public Text description;
    

    private List<string> itensToShow = new List<string>();
    private int selected;
    bool opened;
    private Char persoa;

    private void Start()
    {
        persoa = GetComponent<Char>();
    }

    public void addItem(int id, int count, int mutiplicador)
    {
        bool t = false;
        for (int i = 0; i < itemInInv.Count; i++)
        {
            if (itemInInv[i].id == id)
            {
                itemInInv[i].count += count*mutiplicador;
                t = true;
                break;
            }
        }
        if (t == false)
        {
            itemInInv iii = new itemInInv();
            iii.id = id;
            iii.mutiplicador = mutiplicador;
            iii.count = count*mutiplicador;

            itemInInv.Add(iii);
        }
    }

    public void remItem(int id, int count)
    {
        bool t = false;
        for (int i = 0; i < itemInInv.Count; i++)
        {
            if (itemInInv[i].id == id)
            {
                itemInInv[i].count -= count;
                if (itemInInv[i].count <= 0)
                {
                    itemInInv.Remove(itemInInv[i]);
                }
                t = true;
                break;
            }
        }
        if (t == false)
        {
            print("Item não encontrado!");
        }
    }

    public int verifyItem(int id, int count)
    {
        bool t = false;
        bool c = false;
        for (int i = 0; i < itemInInv.Count; i++)
        {
            if (itemInInv[i].id == id)
            {
                if (itemInInv[i].count >= count)
                {
                    c = true;
                }
                t = true;
                break;
            }
        }
        int v;
        if (t == false)
        {
            v = 0; //Item não encontrado
        }
        else if (c == false)
        {
            v = 1;//Item encontrado, mas sem quantidade suficiente
        }
        else
        {
            v = 2;//Item encontrado com quantidade suficiente
        }
        return v;
    }

    public void inventoryShow(bool option)
    {
        if (option == true)
        {
            itensToShow.Clear();
            selected = 0;
            invScene.SetActive(true);
            persoa.DisableControls();
            for (int i = 0; i < itemInInv.Count; i++)
            {
                int id = itemInInv[i].id;
                if (i == 0)
                    itensToShow.Add("> " + ItemsDB[id].name + " / " + itemInInv[i].count);
                else
                    itensToShow.Add(ItemsDB[id].name + " / " + itemInInv[i].count);
            }

        }
        else
        {
            invScene.SetActive(false);
            persoa.EnableControls();
        }
    }

    private void Update()
    {
        if (opened)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (selected > 0)
                {
                    selectedItem(-1);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selected < itensToShow.Count-1)
                {
                    selectedItem(+1);
                }
            }
            
            }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryShow(!opened);
            reloadInv();
            opened = !opened;
        }

    }

    public void selectedItem(int item)
    {
        selected += item;
        for (int i = 0; i < itensToShow.Count; i++)
        {
            itensToShow[i] = itensToShow[i].Replace(">", "");
            if (i == selected)
            
                itensToShow[i] = ">" + itensToShow[i];
            
        }
        reloadInv();
    }

    public void reloadInv()
    {
        itens.text = "";
        for (int i = 0; i < itensToShow.Count; i++)
        {
            itens.text += itensToShow[i] + "\n";
        }
        description.text = ItemsDB[itemInInv[selected].id].description;
    }
}
