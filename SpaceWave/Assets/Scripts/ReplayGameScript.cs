using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayGameScript : MonoBehaviour
{
    

    // Use this for initialization
    public void OnClick()
    {
        // Save game data

        // Close game
        //  scriptMain.Log("Application Closing");

        enabled = false;

        Debug.Log(enabled);

        Color color = GetComponent<Image>().color;
        GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0);

        SceneManager.LoadScene("test");
        

        MainScript.gameOver = false;
        // Debug.Log(GameOverCanvas.GetComponent<Image>().color);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
