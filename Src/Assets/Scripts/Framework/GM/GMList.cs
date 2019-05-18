using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMList  {

    [GMCommand("@ShowID", 1, "ShowID|显示玩家ID")]
    public string ShowID(string[] args)
    {
        int userid = 666;
        return "user id is : " + userid;
    }

    [GMCommand("@LevelUp", 1, "LevelUp|升级到XX")]
    public string LevelUp(string[] args)
    {
        return "level up to : " + args[0];
    }
}