using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    public Button multiText;

    void Start()
    {
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        multiText = multiText.GetComponent<Button>();
        quitMenu.enabled = false;
        Cursor.visible=true;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        multiText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        multiText.enabled = true;
    }

    public void StartLevel()
    {
        Application.LoadLevel("1");
    }

    public void Multi()
    {
        Application.LoadLevel("2");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
