using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class AnimationAttack : NetworkBehaviour
{
    Animator animator;
    // Use this for initialization
    Envanter er;
    El el;
    YanPanel yan;
    int slotsayi;
    int i;
    public GameObject ep,konsol;
    void Start()
    {
        if (!isLocalPlayer)
        {
            el = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<El>();
            er = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
            yan = GameObject.FindGameObjectWithTag("YanPanel").GetComponent<YanPanel>();
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            slotsayi = yan.slotsayiBelirle();
           
            
            if ((Input.GetButtonDown("Fire1") && er.items[slotsayi].itemtipi == Item.ItemType.Malzeme) && !ep.active && !konsol.active)
            {
                animator.SetBool("Attack", true);
            }
            else
            {
                animator.SetBool("Attack", false);
            }

            if ((Input.GetButtonDown("Fire2") && er.items[slotsayi].itemtipi == Item.ItemType.Yiyecek) && !ep.active && !konsol.active)
            {
                animator.SetBool("Yemek", true);
            }
            else
            {
                animator.SetBool("Yemek", false);
            }
        }
    }


}
