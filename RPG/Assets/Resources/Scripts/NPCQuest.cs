using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCQuest : MonoBehaviour
{
    public Quest quest;
    public Char MC;
    public TextoQuest texto;
    private Collider2D colisor;
    public void Start()
    {
        colisor = MC.GetComponent<Collider2D>();
    }

    public void IniciarQuest()
    {
        quest.isActive = true;
        texto.desc.text = quest.Descrição;
        MC.quest = GetComponent<Quest>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == colisor && MC.quest != null)
        {
            if (!MC.quest.isActive)
            {
                IniciarQuest();
            }
        }
        else if (MC.quest == null && collision == colisor)
        {
            IniciarQuest();
        }
        
    }
}
