using UnityEngine;
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance => instance;

    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log($"Only one instance of {typeof(T).Name} is allowed to exist.");
            Destroy(gameObject);
        }
        else
        {
            instance = (T)this;
        }
        
        //DontDestroyOnLoad(gameObject);
    }

}