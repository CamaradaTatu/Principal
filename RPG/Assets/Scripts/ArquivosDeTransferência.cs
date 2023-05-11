using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArquivosDeTransferência : MonoBehaviour
{
    private Inventory inv;
    public static List<itemInInv> itemInInvs;

    void Start()
    {
        inv = GameObject.FindObjectOfType<Char>().GetComponent<Inventory>();
        itemInInvs = inv.itemInInv;
    }
}
