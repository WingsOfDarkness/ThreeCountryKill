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
    public GameObject historyWnd;
    public Text txtTime;
    public GameObject btnNums;

    private Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();

        btnNums.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("PlayerNum");
        for (int i = 1; i < btnNums.transform.childCount; i++)
        {
            btnNums.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = i.ToString();
            var num = i;
            btnNums.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(() =>
            {
                OnClickBtnNum(btnNums.transform.GetChild(num).GetChild(0).GetComponent<Text>());
            });
        }
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

    // public void OnNumEdited()
    // {
    //     if (int.TryParse(iptNum.text, out int num))
    //     {
    //         if (num > 0 && num < 21)
    //         {
    //             PlayerPrefs.SetString("PlayerNum", iptNum.text);
    //         }
    //         else if(num <=0)
    //         {
    //             iptNum.text = "1";
    //         }
    //         else
    //         {
    //             iptNum.text = "20";
    //         }
    //     }
    //     else
    //     {
    //         iptNum.text = "1";
    //     }
    // }

    public void OnClickBtnNumDisplay()
    {
        _animation.Play("Open");
    }

    public void OnClickBtnNum(Text text)
    {
        btnNums.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = text.text;
        PlayerPrefs.SetString("PlayerNum", text.text);
        _animation.Play("Close");
    }

    public void OnClickBtnHistory()
    {
        historyWnd.SetActive(true);
    }

    private void Update()
    {
        txtTime.text = "刷新倒计时：" + (20 - DateTime.Now.Ticks / 10000000 % 20);
    }
}