using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
public class playerSetup : NetworkBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable;
    [SerializeField] string remoteLayerName = "RemotePlayer";
    public GameObject sceneCamera;
    public GameObject Canvas;
    public GameObject el;
	public GameObject elma;
    void Start()
    {	
        if (!isLocalPlayer)
        {
			
            DisableComponent();
            AssignRemoteLayer();
            Canvas.SetActive(false);
            el.SetActive(false);
			
        }
        else
        {
			
            sceneCamera = GameObject.FindGameObjectWithTag("newcamera");
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }

        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();
        GameManager.RegisterPlayer(_netID,_player);
		
    }

    
    void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    void DisableComponent()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {

            componentsToDisable[i].enabled = false;
        }
    }
    void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }

        GameManager.UnRegisterPlayer(transform.name);
    }
}