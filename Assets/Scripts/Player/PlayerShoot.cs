using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerShoot : NetworkBehaviour {
    public Item item;
    public YanPanel yan;
    public El el; Envanter er;
    int slotsayi;
    int i;
    public playerWeapon weapon;
    private const string PLAYER_TAG = "Player";

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask lm;
    void Start () {

        el = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<El>();
        er = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
        

        if (cam == null)
        {  
            Debug.Log("PlayerShoot: No Camera referenced.");
            this.enabled = false;
        }
	}
    void Update()
    {
        slotsayi = yan.slotsayiBelirle();
        weapon.name = er.items[slotsayi].itemismi;
        weapon.damage = er.items[slotsayi].itemdamage;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    [Client]
    void Shoot()
    {
        RaycastHit _hit;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out _hit, weapon.range, lm))
        {
            if(_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name, weapon.damage);
            }
          
        }
    }

    [Command]
    void CmdPlayerShot(string _playerID, float _damage)
    {
        Debug.Log(_playerID + " has been shot.");

        Player _player = GameManager.GetPlayer(_playerID);
        _player.TakeDamage(_damage);
    }

    
}
