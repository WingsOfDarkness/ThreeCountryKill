using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class KingWnd : MonoBehaviour
{
    public GameObject content;
    public GameObject targetHero;
    public GameObject confirmBtn;
    public GameObject focusWnd;
    public int seed;
    public bool useTimeSeed;
    public List<int> nums;
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
        for (int i = 3 * int.Parse(iptNum.text) - 3; i < 3 * int.Parse(iptNum.text) - 1;)
        {
            int randomIndex = Random.Range(0, MainWnd.notKingSprites.Length);
            if (nums.Contains(randomIndex)) continue;
            nums.Add(randomIndex);
            content.transform.GetChild(i - 3 * int.Parse(iptNum.text) + 3 + 5).GetComponent<Image>().sprite =
                MainWnd.notKingSprites[randomIndex];
            i++;
        }

        nums.Clear();

        for (int i = 0; i < 5;)
        {
            // 随机选择一张图片进行显示
            int randomIndex = Random.Range(0, MainWnd.kingSprites.Length);
            if (nums.Contains(randomIndex)) continue;
            nums.Add(randomIndex);
            content.transform.GetChild(i).GetComponent<Image>().sprite = MainWnd.kingSprites[randomIndex];
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