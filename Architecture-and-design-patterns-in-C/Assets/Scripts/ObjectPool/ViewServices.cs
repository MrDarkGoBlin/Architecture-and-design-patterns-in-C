using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    internal sealed class ViewServices
    {
        private readonly Dictionary<int, ObjectPool> _viewCache = new Dictionary<int, ObjectPool>(12);
        
        public void Create(GameObject gameObject)
        {
            if (!_viewCache.TryGetValue(gameObject.GetInstanceID(), out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(gameObject);
                _viewCache[gameObject.GetInstanceID()] = viewPool;
            }

            viewPool.Pop();
        }

        public void Destroy(GameObject gameObject)
        {
            _viewCache[gameObject.GetInstanceID()].Push(gameObject); 
        }
    }
}
