using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    public class SFXManager : MonoBehaviour
    {
        private string m_tag = "SFXManager";

        [SerializeField] private NotifySoundCollection m_soundRequest;

        [SerializeField] private AudioMixerGroup m_mixingGroup;

        [SerializeField] private List<ClipCollection> m_clipCollections = new List<ClipCollection>();

        private Dictionary<ESources, Dictionary<ESoundTypes, ClipLibrary>> m_clipCollectionDictionaries = new Dictionary<ESources, Dictionary<ESoundTypes, ClipLibrary>>();

        private void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(m_tag);

            if(objs.Length > 1)
            {
                Destroy(this.gameObject);
                return;
            }

            DontDestroyOnLoad(this.gameObject);

            foreach (ClipCollection ClipCollection in m_clipCollections)
            {
                foreach (ESources Source in System.Enum.GetValues(typeof(ESources)))
                {
                    if (ClipCollection.Source == Source)
                    {
                        m_clipCollectionDictionaries.Add(Source, ClipCollection.Collection);
                        break;
                    }
                }
            }
        }

    } 
}
