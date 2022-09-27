using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioManaging
{
    public class AudioObjectPool
    {
        public AudioObjectPool(GameObject _prefab, int _size, Transform _parent)
        {
            m_prefab = _prefab;
            InitPool(_size, _parent);
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

        private void InitPool(int _size, Transform _parent)
        {
            for (int i = 0; i < _size; i++)
            {
                AudioObject tmp = GameObject.Instantiate(m_prefab, _parent).GetComponent<AudioObject>();
                tmp.Initialize(this);
                m_queue.Enqueue(tmp);
            }
        }
    } 
}
