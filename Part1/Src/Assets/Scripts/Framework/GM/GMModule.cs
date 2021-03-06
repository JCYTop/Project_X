﻿using System.Collections.Generic;
using System.Reflection;
using Framework.Singleton;

namespace Framework.GM
{
    public class GMModule
    {
        private static GMModule instance;
        private Dictionary<string, MethodInfo> methods = new Dictionary<string, MethodInfo>();

        public static GMModule Instance()
        {
            if (instance == null)
            {
                instance = SingletonProperty<GMModule>.Instance();
                instance.Init();
            }

            return instance;
        }

        public void Init()
        {
            methods.Clear();
            var type = typeof(GMList);
            var _methods = type.GetMethods();
            foreach (var methodInfo in _methods)
            {
                var attribute = methodInfo.GetCustomAttributes(typeof(GMCommandAttribute), false);
                if (attribute != null && attribute.Length > 0)
                {
                    var gmc = attribute[0] as GMCommandAttribute;
                    methods.Add(gmc.CMD, methodInfo);
                }
            }
        }

        public string Call(string input)
        {
            var tmpStr = input.Split(' ');
            if (methods.ContainsKey(tmpStr[0]))
            {
                var param = new List<string>();
                for (int i = 0; i < tmpStr.Length; i++)
                {
                    param.Add(tmpStr[i]);
                }

                var method = methods[tmpStr[0]];
                var info = method.GetCustomAttributes(typeof(GMCommandAttribute), false)[0] as GMCommandAttribute;
                if (param.Count != info.paramNum)
                    return "Usage: " + info.Des;
                else
                {
                    return methods[tmpStr[0]].Invoke(new GMList(), new object[]
                    {
                        param.ToArray()
                    }) as string;
                }
            }
            else
                return "Command Not Found!";
        }
    }
}