// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

namespace Komutils
{
    public abstract class MonoBehaviourSingletonDDOL<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }


        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}