﻿using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JeepBosco : MonoBehaviour
{
    private int NumCamera = -1;
    Scene scena;
    GameObject giocatore = null;
    GameObject collega1 = null;
    GameObject collega2 = null;
    GameObject cane = null;
    Camera telecameraGiocatore = null;
    private bool intro;
    private bool finale;
    bool canStart = false;
    // Start is called before the first frame update
    void Start()
    {
        intro = true;
        finale = false;
        scena = gameObject.scene;
        cane = GameObject.Find("CaneUnity2");
        giocatore = GameObject.FindGameObjectWithTag("Player");
        collega1 = GameObject.Find("Collega1");
        collega2 = GameObject.Find("Collega2");
        telecameraGiocatore = giocatore.transform.Find("Camera").GetComponent<Camera>();
        if (scena.name == "BoscoCane")
            IntroScenaBosco();
    }

    // Update is called once per frame
    void Update()
    {
        if (scena.name == "BoscoCane")
        {
            if (!intro&&!finale)
            {
                foreach( Renderer daAttivare in collega1.GetComponentsInChildren<Renderer>()){
                    daAttivare.enabled = true;
                }
                foreach (Renderer daAttivare in collega2.GetComponentsInChildren<Renderer>())
                {
                    daAttivare.enabled = true;
                }
                cane.gameObject.transform.Find("Cane.001").GetComponent<Renderer>().enabled = true;
                cane.gameObject.transform.Find("Cane.002").GetComponent<Renderer>().enabled = true;
                cane.GetComponent<Animator>().enabled = true;
                GetComponent<LightUpInteractable>().SetAnimatable(false);
                giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(true);
                giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
                telecameraGiocatore.enabled = true;
                giocatore.GetComponent<CharacterController>().enabled = true ;
                //canStart = GameObject.Find("magliasolida").GetComponent<LightUpInteractable>().GetCollect();
                /*if (canStart)
                {
                    GetComponent<LightUpInteractable>().SetAnimatable(true);
                    if (GetComponent<LightUpInteractable>().GetInteract())
                        FineScenaCasa();
                }*/
            }
        }
    }
    public void FineScenaBosco()
    {
        collega1.GetComponent<Renderer>().enabled = false;
        collega2.GetComponent<Renderer>().enabled = false;
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        telecameraGiocatore.enabled = false;
        GameObject.Find("Cube").GetComponent<BoxCollider>().enabled = false;
    }
    public void IntroScenaBosco()
    {
        telecameraGiocatore.enabled = false;
        giocatore.GetComponent<CharacterController>().enabled = false;
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        cane.gameObject.transform.Find("Cane.001").GetComponent<Renderer>().enabled = false;
        cane.gameObject.transform.Find("Cane.002").GetComponent<Renderer>().enabled = false;
        cane.GetComponent<Animator>().enabled = false;
    }

    public void SetCamera(int number)
    {
        NumCamera = number;
    }
    public int GetCamera()
    {
        return NumCamera;
    }

    public void SetIntro()
    {
        GetComponent<Animator>().SetBool("intro", false);
        intro = false;
    }

    public void DisableCamera(int NumCamera)
    {
        GameObject.Find("GestoreCamere").GetComponent<GestoreCamereBosco>().DisableCamera(NumCamera);
    }
    public void CaricaScenaMenu()
    {
        GameObject.Find("GestoreScene").GetComponent<GestoreScene>().LoadSceneByID(0);
    }

}
