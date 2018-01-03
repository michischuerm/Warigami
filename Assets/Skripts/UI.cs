using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;
	public Button creditsText;
	public Canvas creditsMenu;
	public Canvas controlsMenu;
	public Button controlsText;
		
	
	// Use this for initialization
	void Start () {

		quitMenu = quitMenu.GetComponent<Canvas> ();
		creditsMenu = creditsMenu.GetComponent<Canvas> ();
		controlsMenu = controlsMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		creditsText = creditsText.GetComponent<Button> ();
		quitMenu.enabled = false;
		creditsMenu.enabled = false;
		controlsMenu.enabled = false;
	}
		

	public void CreditsPress ()
	{
		quitMenu.enabled = false;
		creditsMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		creditsText.enabled = false;
		controlsText.enabled = false;
		controlsMenu.enabled = false;
	}

	public void ControlsPress ()
	{
		quitMenu.enabled = false;
		creditsMenu.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
		creditsText.enabled = false;
		controlsText.enabled = false;
		controlsMenu.enabled = true;
	}


	public void noPress()
	{
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		creditsText.enabled = true;
		creditsMenu.enabled = false;
		controlsText.enabled = true;
		controlsMenu.enabled = false;
	}

	public void StartLevel ()
	{
		Application.LoadLevel (1);
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}


}
