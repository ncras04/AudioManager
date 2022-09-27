using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioManaging
{
    public class AudioRequest<EType> where EType : System.Enum
    {
        public EType Type { get; }

        public static AudioRequest<EType> Request(EType _type)
        {
            return new AudioRequest<EType>(_type);
        }
        protected private AudioRequest(EType _type)
        {
            Type = _type;
        }
    }
    public class AudioRequest<ESource, EType> where ESource : System.Enum where EType : System.Enum
    {
        public ESource Source { get; }
        public EType Type { get; }

        public static AudioRequest<ESource, EType> Request(ESource _source, EType _type)
        {
            return new AudioRequest<ESource, EType>(_source, _type);
        }
        protected private AudioRequest(ESource _source, EType _type)
        {
            Source = _source;
            Type = _type;
        }
    } 
}
