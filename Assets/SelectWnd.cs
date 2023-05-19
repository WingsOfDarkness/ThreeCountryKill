using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectWnd : MonoBehaviour
{
    public GameObject kingWnd;
    public GameObject notKingWnd;
    public Text txtTime;
    public InputField iptNum;

    private void Start()
    {
        iptNum.text = PlayerPrefs.GetString("PlayerNum");
    }

    public void OnClickKingWnd()
    {
        kingWnd.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnClickNotKingWnd()
    {
        notKingWnd.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnNumEdited()
    {
        PlayerPrefs.SetString("PlayerNum", iptNum.text);
    }

    private void Update()
    {
        txtTime.text = "刷新倒计时：" + (20 - DateTime.Now.Ticks / 10000000 % 20) +
                       " 当前随机种子：" + (int)(DateTime.Now.Ticks / 200000000 % Int32.MaxValue);
    }
}