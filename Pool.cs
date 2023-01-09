using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : Singleton<Pool>
{
    private Dictionary<string, List<GameObject>> dic;

    private Pool()
    {
        dic = new Dictionary<string, List<GameObject>>();
    }

    // 拿东西
    public GameObject GetObj(string name)
    {
        // 即将返回的游戏对象
        GameObject obj = null;
        // 如果对象池有对象(>0就一定有一个)
        if (dic.ContainsKey(name) && dic[name].Count > 0)
        {
            // 取出该列表中第一个游戏对象
            obj = dic[name][0];
            // 删除列表的第一个游戏对象(因为被拿出去了)
            dic[name].RemoveAt(0);
        }
        // 如果没有游戏对象
        else
        {
            // 那么实例化生成一个游戏对象
            obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            // 放到对象池中
            SetObj(name, obj);
        }

        // 去除名字的 "(Clone)"
        obj.name = name;
        // 将其激活
        obj.SetActive(true);
        // 返回结果
        return obj;
    }

    // 放东西
    public void SetObj(string name, GameObject obj)
    {
        // 将其隐藏
        obj.SetActive(false);
        // 如果有列表
        if (dic.ContainsKey(name))
        {
            // 将游戏对象添加到列表中
            dic[name].Add(obj);
        }
        else
        {
            // 创建一个新列表，将游戏对象添加到列表中
            dic.Add(name, new List<GameObject>() { obj });
        }
    }
}
