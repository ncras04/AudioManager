using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace Audio
{
    public class AudioObject : MonoBehaviour, IPoolable
    {
        public AudioSource Source => m_source;

        private AudioObjectPool m_pool;
        private AudioSource m_source;

        public async void SetCountdown(int _delay)
        {
            await Task.Delay(_delay);

            if (m_pool is not null)
            {
                m_pool.ReturnItem(this);
            }
        }

        public void Initialize(AudioObjectPool _pool)
        {
            m_pool = _pool;
            m_source = GetComponent<AudioSource>();
            Deactivate();
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
