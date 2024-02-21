using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransBetScene : MonoBehaviour
{
    public void LevelIndex(int level)
    {
        SceneManager.LoadScene(level + 1);
    }
}
