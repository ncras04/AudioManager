using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioManaging
{
    public class ObjectPool<T> where T : MonoBehaviour, IPoolable<T>
    {
        public ObjectPool(GameObject _prefab, int _size, Transform _parent)
        {
            m_prefab = _prefab;
            InitPool(_size, _parent);
        }

        private Transform m_parent;
        private GameObject m_prefab;

        private Queue<T> m_queue = new Queue<T>();
        public T GetItem()
        {
            T tmp;

            //TODO: anzahl maximaler objects beschränken und stattdessen ältestes direkt re-usen
            if (m_queue.Count == 0)
            {
                tmp = GameObject.Instantiate(m_prefab).GetComponent<T>();
                tmp.Initialize(this);
                return tmp;
            }

            tmp = m_queue.Dequeue();
            tmp.Reset();

            return tmp;
        }

        public void ReturnItem(T _item)
        {
            _item.Deactivate();
            m_queue.Enqueue(_item);
        }

        private void InitPool(int _size, Transform _parent)
        {
            for (int i = 0; i < _size; i++)
            {
                T tmp = GameObject.Instantiate(m_prefab, _parent).GetComponent<T>();
                tmp.Initialize(this);
                ReturnItem(tmp);
            }
        }
    }
}
