using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioManaging
{
    public class ClipCollection<ESource,EType> : ScriptableObject where ESource : System.Enum where EType : System.Enum
    {
        public ESource Source => m_soundSouce;

        [SerializeField] private ESource m_soundSouce;

        [SerializeField] private List<ClipLibrary<EType>> m_clipLibrary = new List<ClipLibrary<EType>>();

        public Dictionary<EType, ClipLibrary<EType>> Collection
        {
            get
            {
                Dictionary<EType, ClipLibrary<EType>> tmp = new Dictionary<EType, ClipLibrary<EType>>();
                foreach (ClipLibrary<EType> Library in m_clipLibrary)
                {
                    foreach (EType Type in System.Enum.GetValues(typeof(EType)))
                    {
                        if (EqualityComparer<EType>.Default.Equals(Library.Type, Type))
                        {
                            tmp.Add(Type, Library);
                            break;
                        }
                    }
                }
                return tmp;
            }
        }

    } 
}
