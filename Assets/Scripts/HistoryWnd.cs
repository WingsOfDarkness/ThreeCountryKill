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
            for (int j = 0; j < MainWnd.KingSprites.Length; j++)
            {
                if (MainWnd.KingSprites[j].name == imgName)
                {
                    content.transform.GetChild(i).GetComponent<Image>().sprite = MainWnd.KingSprites[j];
                    content.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = imgName;
                    isKing = true;
                    break;
                }
            }

            if (!isKing)
            {
                for (int j = 0; j < MainWnd.NotKingSprites.Length; j++)
                {
                    if (MainWnd.NotKingSprites[j].name == imgName)
                    {
                        content.transform.GetChild(i).GetComponent<Image>().sprite = MainWnd.NotKingSprites[j];
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