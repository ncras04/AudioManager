using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioManaging
{
    public class SFXManager : MonoBehaviour
    {
        private string m_tag = "SFXManager";

        [SerializeField] private NotifySoundCollection m_soundRequest;

        [SerializeField] private AudioMixerGroup m_mixingGroup;

        [SerializeField] private int m_poolSize;
        [SerializeField] private GameObject m_audioObjectPrefab;
        
        [SerializeField] private List<ClipCollection<ESources,ESoundTypes>> m_clipCollections = new List<ClipCollection<ESources, ESoundTypes>>();


        private Dictionary<ESources, Dictionary<ESoundTypes, ClipLibrary<ESoundTypes>>> m_clipCollectionDictionaries = new Dictionary<ESources, Dictionary<ESoundTypes, ClipLibrary<ESoundTypes>>>();

        private AudioObjectPool m_pool;
        private void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(m_tag);

            if(objs.Length > 1)
            {
                Destroy(this.gameObject);
                return;
            }

            DontDestroyOnLoad(this.gameObject);

            m_pool = new AudioObjectPool(m_audioObjectPrefab, m_poolSize, transform);

            foreach (ClipCollection<ESources, ESoundTypes> ClipCollection in m_clipCollections)
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

            m_soundRequest.OnAdd += OnSoundRequest;
        }

        private void OnSoundRequest(SoundRequest _request)
        {
            AudioObject tmp = m_pool.GetItem();
            AudioSource tmpSource = tmp.Source;
            ClipLibrary<ESoundTypes> library = m_clipCollectionDictionaries[_request.Source][_request.Type];
            tmp.name = $"{_request.Source} {_request.Type}-Sound";

            tmp.transform.parent = _request.Parent;
            tmp.transform.position = _request.Position;

            //Beim Object init schon setzen, falls nur ein SFX output
            tmpSource.outputAudioMixerGroup = m_mixingGroup;
            //FileList[0], wenn nicht ein random sound gewählt werden soll
            tmpSource.clip = library.FileList[0];
            tmpSource.volume = library.Volume;

            tmpSource.Play();
            tmp.SetCountdown((int)(tmpSource.clip.length * 1000));

            m_soundRequest.Remove(_request);
        }
    } 
}
