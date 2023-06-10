using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainWnd : MonoBehaviour
{
    public GameObject resetConfirmWnd;
    public GameObject quitConfirmWnd;
    public Sprite[] kingSprites; // 存储所有图片的数组
    public Sprite[] notKingSprites; // 存储所有图片的数组
    public List<Sprite> kingSpritesSelected = new List<Sprite>(); // 存储所有图片的数组
    public List<Sprite>[] notKingSpritesSelected = new List<Sprite>[20]; // 存储所有图片的数组
    public Text txtVersion;
    public Text txtSeed;
    public AudioSource bgmAudio;
    public GameObject btnBgmOn;
    public GameObject btnBgmOff;
    public bool useCustomSeed;
    public int seed;


    public static MainWnd instance { get; private set; }

    private void Start()
    {
        instance = this;

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

        txtVersion.text = "v" + Application.version;
    }

    public void InitSprites()
    {
        if (useCustomSeed)
        {
            Random.InitState(seed);
            txtSeed.text = seed.ToString();
        }
        else
        {
            int timeSeed = (int)(DateTime.Now.Ticks / 200000000 % Int32.MaxValue);
            Random.InitState(timeSeed);
            txtSeed.text = "时间种子:" + timeSeed;
        }

        List<Sprite> kingSpriteAll = new List<Sprite>();
        kingSpriteAll.AddRange(kingSprites);
        List<Sprite> notKingSpriteAll = new List<Sprite>();
        notKingSpriteAll.AddRange(notKingSprites);

        //随机生成主公的主公
        for (int i = 0; i < 5;)
        {
            int randomIndex = Random.Range(0, kingSpriteAll.Count);
            if (kingSpriteAll[randomIndex] == null) continue;
            kingSpritesSelected.Add(kingSpriteAll[randomIndex]);
            kingSpriteAll[randomIndex] = null;
            i++;
        }

        //随机生成主公的非主公
        for (int i = 0; i < 2;)
        {
            int randomIndex = Random.Range(0, notKingSpriteAll.Count);
            if (notKingSpriteAll[randomIndex] == null) continue;
            kingSpritesSelected.Add(notKingSpriteAll[randomIndex]);
            notKingSpriteAll[randomIndex] = null;
            i++;
        }

        List<Sprite> allSprites = new List<Sprite>();
        allSprites.AddRange(kingSpriteAll);
        allSprites.AddRange(notKingSpriteAll);

        //随机生成非主公的武将
        for (int i = 0; i < 20; i++)
        {
            notKingSpritesSelected[i] = new List<Sprite>();
            for (int j = 0; j < 3;)
            {
                int randomIndex = Random.Range(0, allSprites.Count);
                if (allSprites[randomIndex] == null) continue;
                notKingSpritesSelected[i].Add(allSprites[randomIndex]);
                allSprites[randomIndex] = null;
                j++;
            }
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