using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    
    public NPC npc;
    public NPC1 nPC1;
    public Text txt;//Texto UI
    public float cooldown;//Tempo que leva para aparecer cada letra

    private Animator anim;//Animator
    private int selected;//Linha de Dialogo selecionada 
    private string str;//Dialogo a ser escrito

    private Char perso;


    private void Start()
    {
        anim = GetComponent<Animator>(); //Pega o componente
        perso = GameObject.Find("MC").GetComponent<Char>();

    }

    public void showDiolog()
    {
        anim.SetTrigger("open"); //Mostra o dialogo pelo animator
        selected = 0;//Seleciona o 0
        if (npc.condição) { 
            str = npc.falas[selected];//pega o primeiro dialogo
        }
        else if (nPC1.condição) { 
            str = nPC1.falas[selected];
        }
        loadLetters();
        perso.DisableControls();
    }

    public void loadLetters()
    {
        txt.text = "";//Text do UI com o text nulo
        char[] chars = str.ToCharArray();//Transforma a string para char
        for (int i = 0; i < chars.Length; i++)
        {
            StartCoroutine(getLetter(chars[i], i));
        }
    }

    public void nextDialog()
    {
        if (npc.condição)
        {
            if (npc.falas.Count == selected + 1)
            {
                endDialog();
            }
            else
            {
                selected++;
                str = npc.falas[selected];
                loadLetters();
            }
        }
        if (nPC1.condição)
        {
            if (nPC1.falas.Count == selected + 1)
            {
                endDialog();
            }
            else
            {
                selected++;
                str = nPC1.falas[selected];
                loadLetters();
            }
        }
    }

    public void endDialog()
    {
        anim.SetTrigger("close");
        str = "";
        txt.text = "";
        perso.EnableControls();
    }

    IEnumerator getLetter(char c, int i)
    {
        yield return new WaitForSeconds(cooldown * i);
        txt.text += c.ToString();
    }
}
