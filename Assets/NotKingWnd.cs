using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NotKingWnd : MonoBehaviour
{
    public GameObject content;
    public GameObject targetHero;
    public GameObject confirmBtn;
    public GameObject focusWnd;
    public int seed;
    public bool useTimeSeed;
    public List<int> nums = new List<int>();
    public InputField iptNum;


    void OnEnable()
    {
        if (useTimeSeed)
        {
            Random.InitState((int)(DateTime.Now.Ticks / 200000000 % Int32.MaxValue));
        }
        else
        {
            Random.InitState(seed);
        }

        nums = new List<int>();

        //随机生成3*num个随机数
        for (int i = 0; i < 3 * int.Parse(iptNum.text) - 3;)
        {
            int randomIndex = Random.Range(0, MainWnd.notKingSprites.Length);
            if (nums.Contains(randomIndex)) continue;
            nums.Add(randomIndex);
            i++;
        }

        //随机生成两个非主公
        for (int i = 3 * int.Parse(iptNum.text) - 3; i < 3 * int.Parse(iptNum.text);)
        {
            int randomIndex = Random.Range(0, MainWnd.notKingSprites.Length);
            if (nums.Contains(randomIndex)) continue;
            nums.Add(randomIndex);
            content.transform.GetChild(i - 3 * int.Parse(iptNum.text) + 3).GetComponent<Image>().sprite =
                MainWnd.notKingSprites[randomIndex];
            i++;
        }
    }

    public void OnClickHero(GameObject parent)
    {
        targetHero = parent;
        focusWnd.transform.GetChild(0).GetComponent<Image>().sprite = parent.GetComponent<Image>().sprite;
        focusWnd.SetActive(true);
    }

    public void OnClickSubmit()
    {
        if (targetHero == null) return;
        for (int i = 0; i < content.transform.childCount; i++)
        {
            if (content.transform.GetChild(i).gameObject != targetHero)
            {
                Destroy(content.transform.GetChild(i).gameObject);
            }
        }

        targetHero.transform.SetParent(transform);
        targetHero.transform.localPosition = new Vector2(0, 0);
        content.SetActive(false);
        confirmBtn.SetActive(false);
    }
}