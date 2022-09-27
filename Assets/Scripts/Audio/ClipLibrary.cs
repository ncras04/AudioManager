using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Audio
{
    [Serializable]
    public class ClipLibrary
    {
        public AudioClip[] FileList => m_fileReference.AudioClips;
        public float Volume => m_fileReference.Volume;

        public ESoundTypes Type => m_type;

        [SerializeField] private ESoundTypes m_type;
        [SerializeField] private FileVolumeReference m_fileReference;

        [Serializable]
        private class FileVolumeReference
        {
            public AudioClip[] AudioClips => m_audioClips;
            public float Volume => m_volume;

            [SerializeField] [Range(0, 1)] private float m_volume = 1;
            [SerializeField] private AudioClip[] m_audioClips;
        }
    }
}
