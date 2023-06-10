using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NotKingWnd : MonoBehaviour
{
    public GameObject content;
    public FocusWnd focusWnd;
    public Text txtNum;


    void OnEnable()
    {
        MainWnd.instance.InitSprites();
        for (int i = 0; i < 3; i++)
        {
            Transform image = content.transform.GetChild(i);
            image.GetComponent<Image>().sprite = MainWnd.instance.notKingSpritesSelected[int.Parse(txtNum.text) - 1][i];
            image.GetChild(0).GetComponent<Text>().text = image.GetComponent<Image>().sprite.name;
        }
    }


    public void OnClickHero(GameObject parent)
    {
        focusWnd.gameObject.SetActive(true);
        focusWnd.targetHero = parent;
        focusWnd.content = content;
        focusWnd.transform.GetChild(0).GetComponent<Image>().sprite = parent.GetComponent<Image>().sprite;
    }
}