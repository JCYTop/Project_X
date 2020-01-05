/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Test
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/09/15 19:18:40
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Threading.Tasks;
using Framework.Base;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
//        intli.Insert(1);
//        intli.Insert(10);
//        intli.Insert(2);
//        intli.Insert(5);
//        intli.Insert(17);
//        intli.PrintAll();

//        LogUtil.Log("开始获取博客园首页字符数量");
//        Task<int> task1 = CountCharsAsync("http://www.cnblogs.com");
//        LogUtil.Log("开始获取百度首页字符数量");
//        Task<int> task2 = CountCharsAsync("http://www.baidu.com");
//        LogUtil.Log("Main方法中做其他事情");

//        var result = new NativeArray<float>(1, Allocator.Persistent);
//        var jobData = new MyJob();
//        jobData.a = 10;
//        jobData.b = 20;
//        jobData.result = result;
//        var handel = jobData.Schedule();
//        handel.Complete();
//        LogUtil.Log(result[0].ToString());
//        result.Dispose();

//        var a = new NativeArray<float>(2, Allocator.TempJob);
//        var b = new NativeArray<float>(2, Allocator.TempJob);
//        var result = new NativeArray<float>(2, Allocator.TempJob);
//        a[0] = 1.1f;
//        b[0] = 2.2f;
//        a[1] = 3.3f;
//        b[1] = 4.4f;
//        var jobData = new MyParallelJob();
//        jobData.a = a;
//        jobData.b = b;
//        jobData.result = result;
//        var handle = jobData.Schedule(result.Length, 1);
//        handle.Complete();
//        a.Dispose();
//        b.Dispose();
//        result.Dispose();
//
//        var str = "ababcabcacabab";
//        var target = "cab";
//        var list = StringSearch.StringBM(str, target);
//        Debug.Log(list);
//        Tesss();
//        Invoke("Tesss", 3f);
//

//        string c1 = "ababacd";
//        string c2 = "ababacababb";
//        string c3 = "ababacababac";
//        Debug.Log(StringSearch.KMP(c2, "ba"));
    }

    public async void Tesss()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
        UIRootMgr.Instance().SpawnUI("GraphyProfiler", (prefab) => { EntityUtil.InstantiateGo(prefab); });
        await Task.Delay(TimeSpan.FromSeconds(2));
        UIRootMgr.Instance().SpawnUI("Test1", (prefab) => { EntityUtil.InstantiateGo(prefab); });
        await Task.Delay(TimeSpan.FromSeconds(2));
        UIRootMgr.Instance().SpawnUI("Test2", (prefab) =>
        {
            var go = EntityUtil.InstantiateGo(prefab);
            go.GetComponent<UIBase>().Close();
            Invoke("NextGo", 5f);
        });
    }

    private void NextGo()
    {
        UIRootMgr.Instance().SpawnUI("Test2", (prefab) =>
        {
            var go = EntityUtil.InstantiateGo(prefab);
        });
    }

//    async Task<int> CountCharsAsync(string url)
//    {
//        WebClient wc = new WebClient();
//        string result = await wc.DownloadStringTaskAsync(new Uri(url));
//        LogUtil.Log("博客园:" + result.Length);
//        return result.Length;
//    }
}

///// <summary>
///// job 将两个浮点数相加
///// </summary>
//public struct MyParallelJob : IJobParallelFor
//{
//    [ReadOnly] public NativeArray<float> a;
//    [Readonly] public NativeArray<float> b;
//    public NativeArray<float> result;
//
//    public void Execute(int i)
//    {
//        result[i] = a[i] + b[i];
//    }
//}
//
//public struct MyJob : IJob
//{
//    public float a;
//    public float b;
//    public NativeArray<float> result;
//
//    public void Execute()
//    {
//        result[0] = a + b;
//    }
//}