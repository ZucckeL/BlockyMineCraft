using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Networking;

public class OyunAyarlari : NetworkBehaviour {

    public GameObject envanterPanel,karakter,konsolEkran;
    public GameObject aim;
    public bool envanter,konsol;

    void Start()
    {
        if (isLocalPlayer)
        {
            return;
        }

            envanter = false;
        
    }

    void Update()
    {
        //if (!isLocalPlayer)
        //{
        //    return;
       // }
            if (Input.GetKeyDown(KeyCode.I))
            {
                envanter = !envanter;
            }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            konsol = !konsol;
        }
        if (konsol)
        {
            konsolEkran.SetActive(true);
        }
        else
        {
            konsolEkran.SetActive(false);
        }

            if (envanter)
            {
                
                envanterPanel.SetActive(true);
                aim.SetActive(false);
                //karakter.GetComponent<PlayerControllerr>().enabled = false;
               
            }
            else
            {
                envanterPanel.SetActive(false);
                aim.SetActive(true);
                //karakter.GetComponent<PlayerControllerr>().enabled = true;
                
            }

            if(envanter || konsol)
        {
            karakter.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Screen.lockCursor = false;
        }
        else
        {
            karakter.GetComponent<FirstPersonController>().enabled = true;
            Cursor.visible = false;
            Screen.lockCursor = true;
        }
    }
}
