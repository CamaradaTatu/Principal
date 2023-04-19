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
    public bool glicocalix;
    public Quest quest;

    public ManagerScenes ms;
    public string scene;

    private void Awake()
        
    {
        anim = GetComponent<Animator>();
    }


    void Start()
    {
        
    }
    public void HabilitarGlicocalix()
    {
        glicocalix = true;
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
            

                float x = Input.GetAxisRaw("Horizontal");
                float y = Input.GetAxisRaw("Vertical");
                if (y == 1)//w
                {
                    transform.position += new Vector3(0, Speed, 0);
                    SetSpeedB(1);
                }

                else if (x == 1) //D
                {
                    transform.position += new Vector3(Speed, 0, 0);
                    SetSpeedR(1);
                }

                else if (y == -1) //S
                {
                    transform.position += new Vector3(0, -Speed, 0);
                    SetSpeedF(1);
                }

                else if (x == -1) //A
                {
                    transform.position += new Vector3(-Speed, 0, 0);
                    SetSpeedL(1);
                }

                if (Input.GetKeyUp(KeyCode.W))//w
                {
                    SetSpeedB(0);
                }

                else if (Input.GetKeyUp(KeyCode.D)) //D
                {
                    SetSpeedR(0);
                }

                else if (Input.GetKeyUp(KeyCode.S)) //S
                {
                    SetSpeedF(0);
                }

                else if (Input.GetKeyUp(KeyCode.A)) //A
                {
                    SetSpeedL(0);
                }
        }
        if (quest.isActive)
        {
            quest.objetivo.ProgressoColeta(quest.objetivo.QuantRequerida, quest.objetivo.idItem);
            if (quest.objetivo.completou() == true)
            {
                quest.Completo();
            }
        }
        
        
    }
    #endregion

 

}