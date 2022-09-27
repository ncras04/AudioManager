using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioObjectPool
    {
        public AudioObjectPool(GameObject _prefab, int _size)
        {
            m_prefab = _prefab;
            InitPool(_size);
        }

        private Transform m_parent;
        private GameObject m_prefab;

        private Queue<AudioObject> m_queue = new Queue<AudioObject>();
        public AudioObject GetItem()
        {
            AudioObject tmp;

            if (m_queue.Count == 0)
            {
                tmp = GameObject.Instantiate(m_prefab).GetComponent<AudioObject>();
                tmp.Initialize(this);
                return tmp;
            }

            tmp = m_queue.Dequeue();
            tmp.Reset();

            return tmp;
        }

        public void ReturnItem(AudioObject _item)
        {
            _item.Deactivate();
            m_queue.Enqueue(_item);
        }

        private void InitPool(int _size)
        {
            for (int i = 0; i < _size; i++)
            {
                m_queue.Enqueue(GameObject.Instantiate(m_prefab).GetComponent<AudioObject>());
            }
        }
    } 
}
