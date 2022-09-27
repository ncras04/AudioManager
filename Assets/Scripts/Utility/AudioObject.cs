using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace AudioManaging
{
    public class AudioObject : MonoBehaviour, IPoolable<AudioObject>
    {
        public AudioSource Source => m_source;

        private ObjectPool<AudioObject> m_pool;
        private AudioSource m_source;

        public async void SetCountdown(int _delay)
        {
            await Task.Delay(_delay);

            if (m_pool is not null)
            {
                m_pool.ReturnItem(this);
            }
        }

        public void Initialize(ObjectPool<AudioObject> _pool)
        {
            m_pool = _pool;
            m_source = GetComponent<AudioSource>();
        }

        public void Reset()
        {
            gameObject.SetActive(true);
        }
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    } 
}
