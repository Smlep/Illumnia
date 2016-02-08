using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;

    void Start()
    {
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        Application.LoadLevel("1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
