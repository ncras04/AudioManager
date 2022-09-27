using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioManaging;

public interface IPoolable<T> where T : MonoBehaviour, IPoolable<T>
{
    void Reset();
    void Deactivate();

    void Initialize(ObjectPool<T> pool);

}
