using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPosition : MonoBehaviour {

    public GameObject Player;


    void Update()
    {
        
        isRestarter();    
    }
    public void isRestarter()
    {
        if(Player.transform.position.y < 0f)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, 295f, Player.transform.position.z);
        }
    }
}
