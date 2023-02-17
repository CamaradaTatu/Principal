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
        texto.desc.text += "\n"+quest.Descrição;
        MC.quest = quest;
        MC.quest.objetivo = quest.objetivo;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == colisor && MC.glicocalix == false && !MC.quest.isActive)
        {
            IniciarQuest();
        }
    }
}
