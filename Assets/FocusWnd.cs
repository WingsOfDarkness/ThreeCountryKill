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
    public class FocusWnd:MonoBehaviour
    {
        public void OnClickFocus()
        {
            gameObject.SetActive(false);
        }
    }
}