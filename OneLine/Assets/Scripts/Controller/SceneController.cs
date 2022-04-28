using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using System;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    SceneInstance m_LoadedScene;
    bool m_ReddyToLoad = true;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void loadSubScene(string scene)
    {
        if (m_ReddyToLoad)
        {
            Addressables.LoadSceneAsync(scene, LoadSceneMode.Additive).Completed += OnSceneLoaded;
        }
        else
        {
            Addressables.UnloadSceneAsync(m_LoadedScene).Completed += OnSceneUnLoaded;
        }
    }

    void OnSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            m_LoadedScene = obj.Result;
            m_ReddyToLoad = false;
        }
        else
        {
            Debug.Log("로드 실패");
        }
    }

    void OnSceneUnLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            m_ReddyToLoad = true;
            m_LoadedScene = new SceneInstance();
        }
        else
        {
            Debug.Log("언로드 실패");
        }
    }
}
