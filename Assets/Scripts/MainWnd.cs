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
    public static Sprite[] KingSprites; // 存储所有图片的数组
    public static Sprite[] NotKingSprites; // 存储所有图片的数组
    public Text txtVersion;
    public AudioSource bgmAudio;
    public GameObject btnBgmOn;
    public GameObject btnBgmOff;

    private void Start()
    {
        if (KingSprites == null || KingSprites.Length == 0)
        {
            // 获取指定文件夹中的所有图片，存储到textures数组中
            KingSprites = Resources.LoadAll<Sprite>("Kings/");
        }

        if (NotKingSprites == null || NotKingSprites.Length == 0)
        {
            // 获取指定文件夹中的所有图片，存储到textures数组中
            NotKingSprites = Resources.LoadAll<Sprite>("NotKings/");
        }

        txtVersion.text = "v" + Application.version;
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

    public void OnClickBgmOn()
    {
        btnBgmOff.SetActive(true);
        btnBgmOn.SetActive(false);
        bgmAudio.Stop();
    }
    
    public void OnClickBgmOff()
    {
        btnBgmOff.SetActive(false);
        btnBgmOn.SetActive(true);
        bgmAudio.Play();
    }
}