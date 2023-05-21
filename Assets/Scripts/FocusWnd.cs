// /****************************************************
// 	文件：FocusWnd.cs
// 	作者：Apollo
// 	邮箱：apollodragon2020@outlook.com
// 	日期：2023/05/14 19:26
// 	功能：
// *****************************************************/

using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class FocusWnd : MonoBehaviour
    {
        public GameObject targetHero;
        public GameObject content;
        public GameObject confirmBtn;

        public void OnClickFocus()
        {
            gameObject.SetActive(false);
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

            //保存历史记录
            for (int i = 6; i >= 0; i--)
            {
                PlayerPrefs.SetString("HistoryHero" + (i + 1), PlayerPrefs.GetString("HistoryHero" + i));
            }

            PlayerPrefs.SetString("HistoryHero0", targetHero.GetComponent<Image>().sprite.name);

            targetHero.transform.SetParent(content.transform.parent.parent);
            targetHero.transform.localPosition = new Vector2(0, 0);
            content.SetActive(false);
            confirmBtn.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}