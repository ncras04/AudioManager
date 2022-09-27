using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class SoundRequest
    {
        public ESources Source { get; }
        public ESoundTypes Type { get; }

        public bool IsRandomizable { get; }
        public Transform Parent { get;  }
        public Vector3 Position { get; }

        public static SoundRequest Request(ESources _source, ESoundTypes _type, Transform _parent)
        {
            return new SoundRequest(_source, _type, _parent, _parent.position, false);
        }
        private SoundRequest(ESources _source, ESoundTypes _type, Transform _parent, Vector3 _pos, bool _rnd)
        {
            Source = _source;
            Type = _type;
            Parent = _parent;
            Position = _pos;
            IsRandomizable = _rnd;
        }
    } 
}
