/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ssssss
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.1f1
 *CreateTime:   2020/04/03 19:49:05
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ssssss : MonoBehaviour
{
    private async Task Start()
    {
        await Task.Delay(3000);
        var sss = AddressableSyncAdapter.Instantiate("GM");
        Debug.Log($"aeweqaweqwe qwe qweqw e");
        Debug.Log(sss);
    }
}