using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T : class
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)System.Activator.CreateInstance(typeof(T), true);
            }

            return instance;
        }
    }
}

