using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArquivosDeTransferência : MonoBehaviour
{
    public static ArquivosDeTransferência instance;
    public static List<itemInInv> itemInInvs = new List<itemInInv>();
    public Quest quest;
    public Char mc;
    private void Start()
    {
        quest = GetComponent<Quest>();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        
    }

}
