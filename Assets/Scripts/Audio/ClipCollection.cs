using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "ClipCollection", menuName = "Audio/New ClipCollection", order = 0)]
    public class ClipCollection : ScriptableObject
    {
        public ESources Source => m_soundSouce;

        [SerializeField] private ESources m_soundSouce;

        [SerializeField] private List<ClipLibrary> m_clipLibrary = new List<ClipLibrary>();

        public Dictionary<ESoundTypes, ClipLibrary> Collection
        {
            get
            {
                Dictionary<ESoundTypes, ClipLibrary> tmp = new Dictionary<ESoundTypes, ClipLibrary>();
                foreach (var SoundFile in m_clipLibrary)
                {
                    foreach (ESoundTypes Type in System.Enum.GetValues(typeof(ESoundTypes)))
                    {
                        if (SoundFile.Type == Type)
                        {
                            tmp.Add(Type, SoundFile);
                            break;
                        }
                    }
                }
                return tmp;
            }
        }

    } 
}
