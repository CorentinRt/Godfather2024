using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpriteRandomize : MonoBehaviour
{
    public Image Skin1;
    public Image Skin2;
    public Image Skin3;
    public Image Skin4;
    public Image Skin5;

    // Array 
    public Sprite[] images;
    void Start()
    {
        changeImage();
    }

    void changeImage()
    {
        int num = UnityEngine.Random.Range(0, images.Length);
    }
}
