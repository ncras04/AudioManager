using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NotifyCollection<T> : ScriptableObject
{
    private List<T> m_data = new List<T>();

    private event Action<T> m_onAdd;
    private event Action<T> m_onRemove;

    public event Action<T> OnAdd
    {
        add
        {
            m_onAdd -= value;
            m_onAdd += value;
        }

        remove
        {
            m_onAdd -= value;
        }
    }

    public event Action<T> OnRemove
    {
        add
        {
            m_onRemove -= value;
            m_onRemove += value;
        }

        remove
        {
            m_onRemove -= value;
        }
    }

    public void Add(T _obj)
    {
        m_data.Add(_obj);
        m_onAdd?.Invoke(_obj);
    }

    public void Remove(T _obj)
    {
        m_data.Remove(_obj);
        m_onRemove?.Invoke(_obj);
    }
}
