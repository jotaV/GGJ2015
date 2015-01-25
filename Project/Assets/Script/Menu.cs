

using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public double delay;
	public GameObject g;
	private CanvasGroup[] c;
	private bool changed;

	public void Start()
	{
		c = g.GetComponentsInChildren<CanvasGroup>();
		changed = false;
	}

	public void Update()
	{
		if (changed) {
			if (delay < 0)
			{
				OpenWindow ();
				changed = false;
			}
			else
				delay -= 1 * Time.deltaTime;
		}
	}

	public void OpenWindow()
	{
		foreach(CanvasGroup child in c) 
		{
			if (child.gameObject.name != "Canvas")
			{
				if (child.alpha == 0)
				{
					child.alpha = 1;
					break;
				}
				else if (child.alpha > 0.25)
					child.alpha /= 2;
				print (child.alpha + " " + child.gameObject.name);
			}
		}
		changed = true;
	}

	public void Quit(){
		print ("Saiu");
		Application.Quit();
	}
}
