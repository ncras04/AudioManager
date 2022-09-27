using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioManaging
{
    public class AudioRequest<ESource, EType> where ESource : System.Enum where EType : System.Enum
    {
        public ESource Source { get; }
        public EType Type { get; }

        public bool IsRandomizable { get; }
        public Transform Parent { get;  }
        public Vector3 Position { get; }

        public static AudioRequest<ESource, EType> Request(ESource _source, EType _type, Transform _parent)
        {
            return new AudioRequest<ESource, EType>(_source, _type, _parent, _parent.position, false);
        }
        private AudioRequest(ESource _source, EType _type, Transform _parent, Vector3 _pos, bool _rnd)
        {
            Source = _source;
            Type = _type;
            Parent = _parent;
            Position = _pos;
            IsRandomizable = _rnd;
        }
    } 
}
