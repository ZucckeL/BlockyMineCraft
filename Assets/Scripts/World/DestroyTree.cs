using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTree : MonoBehaviour {

    
    private void OnTriggerEnter(Collider other)
    {
	if(other.name == "Wood 1" || other.name == "treeBlock(Clone)"){
		Destroy(other.gameObject);
		}
    }
	
}
