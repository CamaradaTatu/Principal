using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class Quest : MonoBehaviour
{
    public string titulo;
    public string Descrição;
    public NPCQuest nPC;
    public TextoQuest textoQuest;
    public NPC npc;
    public UnityEvent OnQuestEnd;
    public QuestObjetivo objetivo;
    public bool isActive;
    
    public void RemoverDesc(string removivel)
    {
        textoQuest.desc.text = textoQuest.desc.text.Replace(removivel, "").TrimEnd();
    }
    

    public void Completo()
    {
        RemoverDesc(Descrição);
        isActive = false;
        npc.condição = true;
        OnQuestEnd.Invoke();
        Destroy(this);
        Debug.Log(titulo + "completo");
    }
}
