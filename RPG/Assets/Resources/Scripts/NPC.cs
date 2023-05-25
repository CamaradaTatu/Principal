using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class NPC : MonoBehaviour
{
    [Header("EnemyConfig")]
    
    public string name;
    public bool condição = false;
    private Char @char;

    [Header("Imports")]
    public Dialogue dialogue;
    public List<string> falas = new List<string>();
    private Collider2D collider;
    private Quest quest;

    [Header("No Fim Das Falas")]
    public UnityEvent OnDialogueEnd;


    private void Start()
    {
        collider = GameObject.Find("MC").GetComponent<Collider2D>();
        @char = GameObject.Find("MC").GetComponent<Char>();
        quest = GetComponent<Quest>();
    }
    public void descartável()
    {
        quest.textoQuest.desc.text = "> "+@char.quest.Descrição;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collider.tag == "Player" && condição == true)
        {
            dialogue.npc = this;
            dialogue.showDiolog();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collider.tag == "Player" && condição == true)
        {
            OnDialogueEnd.Invoke();
        }
    }
    public void setCondicaoTrue()
    {
        condição = true;
    }
}
