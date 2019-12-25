using System;

namespace Framework.GM
{
    [AttributeUsage(AttributeTargets.Method)]
    public class GMCommandAttribute : Attribute
    {
        public string CMD; //命令名称
        public int paramNum; //参数个数
        public string Des; //字符串说明

        public GMCommandAttribute(string cmd, int paramNum, string des)
        {
            this.CMD = cmd;
            this.paramNum = paramNum;
            this.Des = des;
        }
    }
}