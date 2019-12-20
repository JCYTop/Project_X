/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     StringSearch
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/12/09 22:13:31
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;
using UnityEngine;

public static class StringSearch
{
    private const int size = 256; // 全局变量或成员变量

    /// <summary>
    /// BF字符串搜索
    /// </summary>
    /// <param name="str">主串</param>
    /// <param name="target">模式串</param>
    /// <param name="isRecent">最近跳出</param>
    /// <returns></returns>
    public static List<int> StringBF(string str, string target, bool isRecent = false)
    {
        int i = 0, j = 0;
        var list = new List<int>();
        while (i + j < str.Length)
        {
            if (target[j] == str[i + j])
            {
                j++;
                if (j >= target.Length)
                {
                    list.Add(i);
                    if (isRecent)
                    {
                        //最近跳出
                        return list;
                    }

                    j = 0;
                    i++;
                }
            }
            else
            {
                j = 0;
                i++;
            }
        }

        return list;
    }

    /// <summary>
    /// BM高效算法
    /// </summary>
    /// <param name="str"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static List<int> StringBM(string str, string target)
    {
        var bc = new int [size];
        generateBC(); // 记录模式串中每个字符最后出现的位置
        var suffix = new int[target.Length]; // 根据模式串生成后缀数组
        var prefix = new bool[target.Length];
        generateGS(); // 构建suffix，prefix数组要事先申请好了
        var strI = 0; // 主串的计数
        var tarI = 0; // 模式串的计数,每次进入重置
        var list = new List<int>();
        while (strI <= str.Length - target.Length)
        {
            tarI = 0;
            for (tarI = target.Length - 1; tarI >= 0; --tarI)
            {
                if (str[strI + tarI] != target[tarI])
                {
                    break;
                }
            }

            if (tarI < 0)
            {
                list.Add(strI); // 匹配成功，返回主串与模式串第一个匹配的字符的位置
                strI += 1;
            }
            else
            {
                var bad = tarI - bc[(int) str[strI + tarI]];
                var good = 0;
                if (tarI < target.Length - 1) // 如果有好后缀的话？
                {
                    good = moveByGS();
                }

                strI += Mathf.Max(bad, good);
            }
        }

        return list;

        //内部方法
        int moveByGS()
        {
            var k = target.Length - 1 - tarI; // 好后缀长度
            if (suffix[k] != -1)
            {
                return tarI - suffix[k] + 1;
            }

            for (int r = tarI + 2; r <= target.Length - 1; ++r) // 为什么+2？
            {
                if (prefix[target.Length - r])
                {
                    return r;
                }
            }

            return target.Length;
        }

        //生成好字符关系表
        void generateGS()
        {
            for (int i = 0; i < target.Length; ++i)
            {
                // 初始化
                suffix[i] = -1;
                prefix[i] = false;
            }

            for (int i = 0; i < target.Length - 1; i++)
            {
                var j = i;
                var k = 0; // 公共后缀子串长度
                while (j >= 0 && target[j] == target[target.Length - 1 - k])
                {
                    --j;
                    ++k;
                    suffix[k] = j + 1; // j+1表示公共后缀子串在b[0, i]中的起始下标 ***妙啊*** 正好寻找最右边
                }

                if (j == -1)
                {
                    prefix[k] = true; // 如果公共后缀子串也是模式串的前缀子串(前缀子串 和 后缀子串 得到了匹配)
                }
            }
        }

        //生成坏字符关系表
        void generateBC()
        {
            for (int i = 0; i < size; i++)
            {
                bc[i] = -1;
            }

            for (int i = 0; i < target.Length; i++)
            {
                var ascii = (int) target[i];
                bc[ascii] = i;
            }
        }
    }

    public static List<int> KMP(string str, string target)
    {
        var list = new List<int>();
        int[] next;
        getNexts();
        var j = 0;
        for (int i = 0; i < str.Length; i++)
        {
            while (j > 0 && str[i] != target[j]) //找到模式串中断位置
            {
                j = next[j - 1] + 1; //KMP跳跃
            }

            if (str[i] == target[j]) //主串与模式串每个字符相匹配
            {
                j++;
            }

            if (j == target.Length) //完成一次匹配 TODO 改成多匹配
            {
                list.Add(i + 1 - target.Length);
                j = 0;
            }
        }

        return list;

        //构建失效指针
        void getNexts()
        {
            //b, m
            next = new int [target.Length];
            next[0] = -1;
            var k = -1;
            for (int i = 1; i < target.Length; i++)
            {
                while (k != -1 && target[k + 1] != target[i])
                {
                    k = next[k];
                }

                if (target[k + 1] == target[i])
                {
                    k++;
                }

                next[i] = k;
            }
        }
    }
}