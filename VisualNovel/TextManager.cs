using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* A script dedicated to formatting and creating texts for actors.
 * Also is in charge of logging information.
 * @author John Angeles
 */
public class TextManager : MonoBehaviour
{
    /* The log button manager.
     */
	private LogButtonManager _logButtonManager;

    private void Awake()
    {
        _logButtonManager = GetComponent<LogButtonManager>();
        Debug.Log("Start occured");
    }

    //The sprite/image used for all textbubbles.
    public Image _textBubbleImage;

    //Once textboxes hit this, then we can stop moving them upward.
    public GameObject _oldTextPosition;
    public GameObject _newTextPosition;

    //The textbox responsible for logging all of the dialogue that happens between each character
    public GameObject _characterLogTextbox;

    /// <summary>
    /// Processes a new piece of text. Basically the latest text we add will appear
    /// at the bottom of the screen, while the older text will "float" to the
    /// top of the screen.
    /// </summary>
    public void ProcessText(Text newText, int actorPosition, string actorName)
    {
        TextBubble newTextToAdd;
        if (newText == null)
        {
            newTextToAdd = null;
        }
        else // If the text happens to be not empty...
        {
            Image toAdd = Instantiate(_textBubbleImage) as Image;

            // If the actor is on the right, then we invert the textbubble.
            if (actorPosition % 2 != 0)
            {
                toAdd.transform.localEulerAngles = new Vector3(0, 180, 0);
            }
            newTextToAdd = new TextBubble(toAdd, newText, _newTextPosition, _oldTextPosition);

            // Record everything into the log.
            _logButtonManager.Record(newText.text, actorName);
        }
        if (activeTextBubbles[1] != null)
        {
            activeTextBubbles[1].Delete();
        }
        activeTextBubbles[1] = null;

        if (activeTextBubbles[0] != null)
        {
            activeTextBubbles[0].Rise();
        }
        activeTextBubbles[1] = activeTextBubbles[0];
        activeTextBubbles[0] = newTextToAdd;
    }

    /// <summary>
    /// Array of active text bubbles. 0th element is the newer textbubble,
    /// while the 1st element is the older textbubble.
    /// </summary>
    private TextBubble[] activeTextBubbles = new TextBubble[2];

    /// <summary>
    /// A text bubble. Contains both a textbubble and the image.
    /// Also contains the position of the textbubble to place it once
    /// @author John Angeles
    /// </summary>
    public class TextBubble
    {
        //Constructor. Takes an image and a text, and constructs a textbubble like so.
        public TextBubble (Image _image, Text _text, GameObject newTextPos, GameObject oldTextPos)
        {
            // Set variables
            image = _image;
            text = _text;
            maxY = oldTextPos.transform.position;
            oldTextPosition = oldTextPos;
            deleteAfterFloatingUp = false;

            // Set the initial transforms of the image and the text
            image.transform.position = newTextPos.transform.position;
            text.transform.position = newTextPos.transform.position;

            // Then, format the textbox image so that it encompasses the text.
            image.transform.localScale = text.transform.localScale;

            // Finally, make the image and text children of our new text position.
            image.transform.SetParent(newTextPos.transform);
            text.transform.SetParent(newTextPos.transform);
        }

        /// <summary>
        /// Rise this text bubble until we hit  oldTextPosition.
        /// </summary>
        public void Rise()
        {
            if (deleteAfterFloatingUp)
            {
                return;
            }
            // Animate the rise
            image.transform.position = maxY;
            text.transform.position = maxY;
            image.transform.SetParent(oldTextPosition.transform);
            text.transform.SetParent(oldTextPosition.transform);

            if (!deleteAfterFloatingUp)
            {
                deleteAfterFloatingUp = true;
            }  
        }

        //Delete the instantiated image and text
        public void Delete()
        {
            for (int i = 1; i >= 0; --i)
            {
              
                GameObject.Destroy(oldTextPosition.transform.GetChild(i).gameObject);
            }
        }

        /// <summary>
        /// The image of this text bubble.
        /// </summary>
        Image image;

        /// <summary>
        /// The text of this text bubble.
        /// </summary>
        Text text;

        /// <summary>
        /// The highest point in which we can raise this text bubble.
        /// </summary>
        Vector3 maxY;

        /// <summary>
        /// Old text position gameObject
        /// </summary>
        GameObject oldTextPosition;

        // If this is true, we delete the text box after we have floated it upwards.
        bool deleteAfterFloatingUp;

        // Here are some useful getter functions
        public Image TextBubbleImage
        {
            get { return image; }
        }

        public Text TextBubbleActualText
        {
            get { return text; }
        }

        public Vector3 MaximumY
        {
            get { return maxY; }
        }

    }

}
