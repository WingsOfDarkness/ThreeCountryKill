using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class KingWnd : MonoBehaviour
{
    public GameObject content;
    public FocusWnd focusWnd;

    void OnEnable()
    {
        MainWnd.instance.InitSprites();
        for (int i = 0; i < 7; i++)
        {
            Transform image = content.transform.GetChild(i);
            image.GetComponent<Image>().sprite = MainWnd.instance.kingSpritesSelected[i];
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