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

    // �ö���
    public GameObject GetObj(string name)
    {
        // �������ص���Ϸ����
        GameObject obj = null;
        // ���������ж���(>0��һ����һ��)
        if (dic.ContainsKey(name) && dic[name].Count > 0)
        {
            // ȡ�����б��е�һ����Ϸ����
            obj = dic[name][0];
            // ɾ���б�ĵ�һ����Ϸ����(��Ϊ���ó�ȥ��)
            dic[name].RemoveAt(0);
        }
        // ���û����Ϸ����
        else
        {
            // ��ôʵ��������һ����Ϸ����
            obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            // �ŵ��������
            SetObj(name, obj);
        }

        // ȥ�����ֵ� "(Clone)"
        obj.name = name;
        // ���伤��
        obj.SetActive(true);
        // ���ؽ��
        return obj;
    }

    // �Ŷ���
    public void SetObj(string name, GameObject obj)
    {
        // ��������
        obj.SetActive(false);
        // ������б�
        if (dic.ContainsKey(name))
        {
            // ����Ϸ������ӵ��б���
            dic[name].Add(obj);
        }
        else
        {
            // ����һ�����б�����Ϸ������ӵ��б���
            dic.Add(name, new List<GameObject>() { obj });
        }
    }
}
