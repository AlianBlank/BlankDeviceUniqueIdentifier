// /**
//  *　　　　　　　　┏┓　　　┏┓+ +
//  *　　　　　　　┏┛┻━━━┛┻┓ + +
//  *　　　　　　　┃　　　　　　　┃ 　
//  *　　　　　　　┃　　　━　　　┃ ++ + + +
//  *　　　　　　 ████━████ ┃+
//  *　　　　　　　┃　　　　　　　┃ +
//  *　　　　　　　┃　　　┻　　　┃
//  *　　　　　　　┃　　　　　　　┃ + +
//  *　　　　　　　┗━┓　　　┏━┛
//  *　　　　　　　　　┃　　　┃　　　　　　　　　　　
//  *　　　　　　　　　┃　　　┃ + + + +
//  *　　　　　　　　　┃　　　┃　　　　Code is far away from bug with the animal protecting　　　　　　　
//  *　　　　　　　　　┃　　　┃ + 　　　　神兽保佑,代码无bug　　
//  *　　　　　　　　　┃　　　┃
//  *　　　　　　　　　┃　　　┃　　+　　　　　　　　　
//  *　　　　　　　　　┃　 　　┗━━━┓ + +
//  *　　　　　　　　　┃ 　　　　　　　┣┓
//  *　　　　　　　　　┃ 　　　　　　　┏┛
//  *　　　　　　　　　┗┓┓┏━┳┓┏┛ + + + +
//  *　　　　　　　　　　┃┫┫　┃┫┫
//  *　　　　　　　　　　┗┻┛　┗┻┛+ + + +
//  *
//  *
//  * ━━━━━━感觉萌萌哒━━━━━━
//  * 
//  * 说明：
//  * 
//  * 文件名：BlankDeviceUniqueIdentifier.cs
//  * 创建时间：2016年08月16日 
//  * 创建人：Blank Alian
//  */
using UnityEngine;
#if UNITY_IOS || UNITY_IPHONE
using System.Runtime.InteropServices;
#endif
/// <summary>
/// 获取Android 和 IOS 的唯一机器码
/// </summary>
public class BlankDeviceUniqueIdentifier
{

    #region 获取设备机器码

#if UNITY_IOS || UNITY_IPHONE

        [DllImport("__Internal")]
        private static extern string DeviceUniqueId();
#endif

    /// <summary>
    /// 获取设备机器码
    /// </summary>
    /// <returns></returns>
    public static string DeviceUniqueIdentifier
    {
        get
        {
            string id = PlayerPrefs.GetString("DeviceUniqueIdentifierID");
            if (string.IsNullOrEmpty(id) || id == "null" || id.Length < 4)
            {
#if UNITY_IOS || UNITY_IPHONE
		            string sid = DeviceUniqueId();
#else
                string sid = SystemInfo.deviceUniqueIdentifier;
#endif
                PlayerPrefs.SetString("DeviceUniqueIdentifierID", sid);
                return sid;
            }
            return id;
        }
    }
    #endregion
}
