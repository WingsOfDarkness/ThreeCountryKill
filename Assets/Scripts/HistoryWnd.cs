using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryWnd : MonoBehaviour
{
    public GameObject content;

    void OnEnable()
    {
        for (int i = 0; i < content.transform.childCount; i++)
        {
            string imgName = PlayerPrefs.GetString("HistoryHero" + i);
            bool isKing = false;
            bool isNotKing = false;
            for (int j = 0; j < MainWnd.instance.kingSprites.Length; j++)
            {
                if (MainWnd.instance.kingSprites[j].name == imgName)
                {
                    content.transform.GetChild(i).GetComponent<Image>().sprite = MainWnd.instance.kingSprites[j];
                    content.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = imgName;
                    isKing = true;
                    break;
                }
            }

            if (!isKing)
            {
                for (int j = 0; j < MainWnd.instance.notKingSprites.Length; j++)
                {
                    if (MainWnd.instance.notKingSprites[j].name == imgName)
                    {
                        content.transform.GetChild(i).GetComponent<Image>().sprite = MainWnd.instance.notKingSprites[j];
                        content.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = imgName;
                        isNotKing = true;
                        break;
                    }
                }
            }

            if (!isKing && !isNotKing)
            {
                content.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "空";
            }
        }
    }

    public void OnClickReturn()
    {
        gameObject.SetActive(false);
    }
}