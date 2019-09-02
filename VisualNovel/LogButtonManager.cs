using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Script that handles the log button.
 * @author John Angeles
 */
public class LogButtonManager : MonoBehaviour
{
    private void Start()
    {
        _scrollBar.SetActive(false);
    }

    //Character array so that we can display everything on the TextBox.
    private List<string> characterLogList = new List<string>();

	//The textbox responsible for logging all of the dialogue that happens between each character
	public GameObject _characterLogTextbox;

	//The scrollbar so that we can activate or deactivate it.
	public GameObject _scrollBar;

	/* Assumes that the button to open the log has been clicked. Opens the log.
     */
	public void OpenLog()
	{
		if (_scrollBar.active)
		{
			_scrollBar.SetActive(false);
		}
		else
		{
			_scrollBar.SetActive(true);
		}

		// Then update it.
		FlushLogOut();
	}

    /* Clears the log, as well as the list.
     */
    public void ResetLog()
    {
        characterLogList = new List<string>();
        _characterLogTextbox.GetComponent<Text>().text = "";
    }

	// Updates the log.
	private void FlushLogOut()
	{
		string adder = null;
		foreach (string currstring in characterLogList)
		{
			adder += currstring;
		}
        _characterLogTextbox.GetComponent<Text>().text = adder;
    }

	/* Records the text said by actorName so we can log it. Assumes that the text is at least one character long.
     */
	public void Record(string text, string actorName)
	{
		string toRecord = actorName + ": " + text + "\n";
		characterLogList.Add(toRecord);
	}
}
