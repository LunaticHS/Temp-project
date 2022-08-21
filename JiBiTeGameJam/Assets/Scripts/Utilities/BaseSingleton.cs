using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingleton<T> where T : new()
{
    private static T m_Instance;

    public static T instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new T();
            }
            return m_Instance;
        }
    }
}
