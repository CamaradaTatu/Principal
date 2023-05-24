using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemImage : MonoBehaviour
{
    public Sprite ItemInvsprite;
    private Image image;
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }
    private void Update()
    {
        image.sprite = ItemInvsprite;
        if(!image.sprite.Equals(null))
        {
            image.color = new Color32(255, 255, 255, 255);
        }
    } 
}
