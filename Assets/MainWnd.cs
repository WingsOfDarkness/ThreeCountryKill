using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainWnd : MonoBehaviour
{
    public GameObject resetConfirmWnd;
    public GameObject quitConfirmWnd;
    public static Sprite[] kingSprites; // 存储所有图片的数组
    public static Sprite[] notKingSprites; // 存储所有图片的数组

    private void Start()
    {
        if (kingSprites == null || kingSprites.Length == 0)
        {
            // 获取指定文件夹中的所有图片，存储到textures数组中
            kingSprites = Resources.LoadAll<Sprite>("Kings/");
        }

        if (notKingSprites == null || notKingSprites.Length == 0)
        {
            // 获取指定文件夹中的所有图片，存储到textures数组中
            notKingSprites = Resources.LoadAll<Sprite>("NotKings/");
        }
    }

    public void OnClickResetConfirm()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickResetCancel()
    {
        resetConfirmWnd.SetActive(false);
    }
    
    public void OnClickQuitConfirm()
    {
        Application.Quit();
    }

    public void OnClickQuitCancel()
    {
        quitConfirmWnd.SetActive(false);
    }
    
    public void OnClickReset()
    {
        resetConfirmWnd.SetActive(true);
    }
    
    public void OnClickQuit()
    {
        quitConfirmWnd.SetActive(true);
    }
}