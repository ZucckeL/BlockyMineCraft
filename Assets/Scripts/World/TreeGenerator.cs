using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeGenerator : MonoBehaviour
{
   
    int Tmp;
    public GameObject chunckPrefab;
    void Update()
    {
        Tmp = Random.Range(0, 100);
        generateTree(gameObject.transform.position);
    }


    public void generateTree(Vector3 pos)
    {
        

        if (Tmp < 5)
        {
            if (pos.y > 133f && pos.y < 147f)
            {
                Debug.Log(pos);
                //GameObject go = Instantiate(chunckPrefab, new Vector3(transform.position.x - 0.5f,pos.y + 0.5f, transform.position.z - 0.5f), Quaternion.identity) as GameObject;
                
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
       // other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z);
    }
}