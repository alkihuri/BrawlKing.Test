using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSinglethon  <T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    #region Properties
    /// <summary>
    /// Take you an object that you wish.
    /// If instance previously created then return it,
    /// else try to find object in scene.
    /// If object not exist in scene, then create and
    /// return it.
    /// If match objects more than one, then debug error
    /// and return null.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            else
            {
                T [] findedObjects = FindObjectsOfType<T>();

                // Create singleton.
                if (findedObjects.Length == 0)
                    return _instance = new GameObject(string.Format("{0}", typeof(T).ToString())).AddComponent<T>();

                // Return singleton.
                if (findedObjects.Length == 1)
                    return _instance = findedObjects[0];

                throw new System.Exception($"Scene have more than one components of <{typeof(T)}> type");
            }
        }
    }
    #endregion

    protected virtual void Awake() => _instance = GetComponent<T>();
}
