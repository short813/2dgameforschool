using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu_script : MonoBehaviour {
    public Canvas quitMenu;
    // start button
    public Button startText;
    // exit button
    public Button exitText;
    public Button Credits;


	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        Credits = Credits.GetComponent<Button>();
        quitMenu.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Creditscreen()
    {
        Application.LoadLevel(3);
    }
    public void ExitPress()
    {
        // show quit menu
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;

    }
public void NoPress()
    // when you press no on the exit screen  
    {
        quitMenu.enabled = false;
        //show play button
        startText.enabled = true;
        //show exit button
        exitText.enabled = true;
    }
    public void StartLevel()
    {
        // loads level 1
        Application.LoadLevel(1);
    }
    public void ExitGame()
    {
        // quits the game
        Application.Quit();
    }

}
