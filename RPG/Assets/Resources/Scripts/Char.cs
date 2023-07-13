using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Char : MonoBehaviour
{
    [Header("CharConfig")]
    public float Speed;
    [Header("Imports")]
    public Camera cam;
    public TextoQuest texto;
    private bool canControl = true;

    private Vector3 goTo = new Vector3(0, 0, -10);

    private Animator anim;
    private Transform transformSave;
    public bool glicocalix;
    public Quest quest;

    public ManagerScenes ms;
    public string scene;


    private void Awake()       
    {
        anim = GetComponent<Animator>();
        transformSave = GameObject.Find("TransformTpSave").GetComponent<Transform>();
    }


    void Start()
    {

    }
    public void HabilitarGlicocalix()
    {
        glicocalix = true;
    }
    public IEnumerator trocarAnimadores()
    {
        if (scene == "Dentro")
        {
            anim.Play("TP");
            yield return new WaitForSeconds(2);
            anim.runtimeAnimatorController = Resources.Load("Animations/McAnim/MC Celula") as RuntimeAnimatorController;
            transform.position = transformSave.position;            
        }
        else if (scene == "Organismo")
        {
            anim.runtimeAnimatorController = Resources.Load("Animations/McAnim/MC") as RuntimeAnimatorController;
            transformSave.position = transform.position;
            transform.position = ms.transform.position;
            anim.Play("TPinvertido");
            yield return new WaitForSeconds(2);
        }
    }
    #region Moviment
    private void SetSpeedF(int speedF)
    {
        anim.SetInteger("SpeedF", speedF);
    }
    private void SetSpeedB(int speedB)
    {
        anim.SetInteger("SpeedB", speedB);
    }
    private void SetSpeedL(int speedL)
    {
        anim.SetInteger("SpeedL", speedL);
    }
    private void SetSpeedR(int speedR)
    {
        anim.SetInteger("SpeedR", speedR);
    }

    public void DisableControls()
    {
        canControl = false;
        SetSpeedF(0);
        SetSpeedB(0);
        SetSpeedL(0);
        SetSpeedR(0);
    }
    public void EnableControls()
    {
        canControl = true;
    }
    


    private void Update()
    {
        
        if (canControl == true)
        {

                 if (Input.GetKey(KeyCode.W))//w
                {
                    SetSpeedF(0);
                    transform.position += new Vector3(0, Speed, 0);
                    SetSpeedB(1);
                }

                else if (Input.GetKey(KeyCode.D)) //D
                {
                    SetSpeedL(0);
                    transform.position += new Vector3(Speed, 0, 0);
                    SetSpeedR(1);
                }

                else if (Input.GetKey(KeyCode.S)) //S
                {
                    transform.position += new Vector3(0, -Speed, 0);
                    SetSpeedF(1);
                }

                else if (Input.GetKey(KeyCode.A)) //A
                {
                    transform.position += new Vector3(-Speed, 0, 0);
                    SetSpeedL(1);
                }

                if (Input.GetKeyUp(KeyCode.W))//w
                {
                    transform.position += new Vector3(0,0,0);
                    SetSpeedB(0);
                }

                else if (Input.GetKeyUp(KeyCode.D)) //D
                {
                    transform.position += new Vector3(0,0,0);
                    SetSpeedR(0);    
                }

                else if (Input.GetKeyUp(KeyCode.S)) //S
                {
                    transform.position += new Vector3(0,0,0);                   
                    SetSpeedF(0);
                }

                else if (Input.GetKeyUp(KeyCode.A)) //A
                {
                    transform.position += new Vector3(0,0,0);                    
                    SetSpeedL(0);
                }
        }
        #endregion
        #region QuestRegion

        if (quest != null)
        {
            if (quest.isActive)
            {
                if (quest.objetivo.tipoObjetivo == TipoObjetivo.Colete)
                {
                    quest.objetivo.ProgressoColeta(quest.objetivo.QuantRequerida, quest.objetivo.idItem);
                }
                if (quest.objetivo.tipoObjetivo == TipoObjetivo.pressioneBotão && Input.GetKeyDown(quest.objetivo.keyCode))
                {
                    for (int i = 0; i < quest.objetivo.QuantAtual.Count; i++)
                    {
                        quest.objetivo.QuantAtual[i]++;
                    }
                }
                if (quest.objetivo.completou() == true)
                {
                    quest.Completo();
                }
            }
        }
        #endregion

    }

}