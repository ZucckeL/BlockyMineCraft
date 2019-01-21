using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textureSettings : MonoBehaviour {
    public Block cube;
    public Text bname;
    public GameObject img1,img2,img3;
    public int tX, tY, sX, sY, bX, bY;
	public int hp;
    public void Update()
    {
       
        cube = new Block(name, false, tX, tY, sX, sY, bX, bY,hp);
    }
    public void Text_changed()
    {
        string temp = bname.text;

        cube.BlockName = temp;
        Debug.Log(cube.BlockName);
            

    }
}
