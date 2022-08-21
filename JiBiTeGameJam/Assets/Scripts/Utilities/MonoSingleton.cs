/// <summary>
/// Generic Mono singleton.
/// </summary>
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{

    private static T m_Instance;

    public static T instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<T>();
                if (m_Instance == null)
                {
                    m_Instance = new GameObject("Singleton of " + typeof(T).ToString(), typeof(T)).GetComponent<T>();
                }

            }
            return m_Instance;
        }
    }

    protected virtual void Awake()
    {
        if (m_Instance == null)
            m_Instance = (T)this;
        else if (m_Instance != this)
            Destroy(gameObject);

    }
    protected virtual void OnDestroy()
    {
        if (m_Instance == this)
            m_Instance = null;
    }
}