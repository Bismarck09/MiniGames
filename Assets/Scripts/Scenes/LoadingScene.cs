using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private SceneAsset _scene;

    public void LoadScene()
    {
        Scene.LoadScene(_scene.name);
    }
}
