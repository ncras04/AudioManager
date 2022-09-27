using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class ClipCollection<Emitter,Type> : ScriptableObject where Emitter : System.Enum where Type : System.Enum
    {
        public Emitter Source => m_soundSouce;

        [SerializeField] private Emitter m_soundSouce;

        [SerializeField] private List<ClipLibrary<Type>> m_clipLibrary = new List<ClipLibrary<Type>>();

        public Dictionary<Type, ClipLibrary<Type>> Collection
        {
            get
            {
                Dictionary<Type, ClipLibrary<Type>> tmp = new Dictionary<Type, ClipLibrary<Type>>();
                foreach (ClipLibrary<Type> Library in m_clipLibrary)
                {
                    foreach (Type Type in System.Enum.GetValues(typeof(Type)))
                    {
                        //TODO: wenns richtig abfragt, dann haben wir gewonnen
                        if (EqualityComparer<Type>.Default.Equals(Library.Type, Type));
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
