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

    /**
     *   Android 资料来源 https://stackoverflow.com/questions/2785485/is-there-a-unique-android-device-id/5626208#5626208
     *
     *   iOS  资料来源于 支付宝使用的 SSKeyChain  钥匙串存储
     *   
     */


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
#if UNITY_EDITOR || UNITY_STANDALONE 
                string sid = SystemInfo.deviceUniqueIdentifier;
#else

#if UNITY_IOS || UNITY_IPHONE
                string sid = DeviceUniqueId();
#elif UNITY_ANDROID
                AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.alianhome.deviceuniqueidentifier.MainActivity");
                string sid = androidJavaObject.CallStatic<string>("DeviceUniqueIdentifier");
#else
                string sid = SystemInfo.deviceUniqueIdentifier;
#endif


#endif
                sid = sid.Replace("-", "");
                sid = sid.Substring(0, 32);
                PlayerPrefs.SetString("DeviceUniqueIdentifierID", sid);
                return sid;
            }
            return id;
        }
    }
    #endregion
}
