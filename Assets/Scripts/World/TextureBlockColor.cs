using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureBlockColor : MonoBehaviour {

    public GameObject TextureImg;
    public GameObject r, g, b;
    public GameObject cube;


    public void TextureColorChange()
    {
        TextureImg.GetComponent<Image>().color = new Vector4(r.GetComponent<Slider>().value, g.GetComponent<Slider>().value, b.GetComponent<Slider>().value, 1f);

    }
   



}
