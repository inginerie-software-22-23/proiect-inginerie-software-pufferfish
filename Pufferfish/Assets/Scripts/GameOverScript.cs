using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverScript : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GameButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
