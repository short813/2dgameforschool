using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Return_to_credits : MonoBehaviour {
    public Canvas QuitMenu;
    public Button Click;


    // Use this for initialization
    void Start()
    {
        QuitMenu = QuitMenu.GetComponent<Canvas>();
        Click = Click.GetComponent<Button>();
        QuitMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
   public void Return()
    {
        QuitMenu.enabled = true;
    }
    public void NoPress()
    {
        QuitMenu.enabled = false;
    }
    public void StartLevel()
    {
        // loads the credits
        Application.LoadLevel(3);
    }

}

