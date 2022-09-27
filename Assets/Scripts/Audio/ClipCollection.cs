using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "ClipCollection", menuName = "Audio/New ClipCollection", order = 0)]
    public class ClipCollection : ScriptableObject
    {
        [SerializeField] private ESources m_soundSouce;

        [SerializeField] private List<ClipLibrary> m_clipLibrary = new List<ClipLibrary>();
    } 
}
