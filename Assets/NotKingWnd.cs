using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NotKingWnd : MonoBehaviour
{
    public GameObject content;
    public FocusWnd focusWnd;
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
        focusWnd.gameObject.SetActive(true);
        focusWnd.targetHero = parent;
        focusWnd.content = content;
        focusWnd.transform.GetChild(0).GetComponent<Image>().sprite = parent.GetComponent<Image>().sprite;
    }
}