using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class credit_screen_script : MonoBehaviour {
    public Canvas credits;
    public Button sources;
    public Button Haval;
    public Button Return;
    public Button leave;


    // Use this for initialization
	void Start () {
        credits = credits.GetComponent<Canvas>();
        sources = sources.GetComponent<Button>();
        Haval = Haval.GetComponent<Button>();
        Return = Return.GetComponent<Button>();
        leave = leave.GetComponent<Button>();
        credits.enabled = true;


    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
public void Sources()
    {
        Application.LoadLevel(5);
    }
public void HI()
    {
        Application.LoadLevel(4);

    }
public void ReturnToMenu()
    {
        Application.LoadLevel(0);

    }
public void Exit()
    {
        Application.Quit();
    }
}
