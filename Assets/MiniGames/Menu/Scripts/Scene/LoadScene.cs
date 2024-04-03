using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private SceneAsset _sceneName;

    public void LoadingScene()
    {
        Scene.LoadScene(_sceneName.name);
    }
}
