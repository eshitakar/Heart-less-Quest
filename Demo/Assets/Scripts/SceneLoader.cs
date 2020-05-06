using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}