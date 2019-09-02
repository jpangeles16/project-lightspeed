using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

/* Copied from BasicInkExample. Abstracted away from me, but
 * I made some pretty useful modifications
 * @author InkDevelopers and @author John Angeles
 */
public class InkManager : MonoBehaviour
{
    
    void Start()
    {
        // Remove the default message
        RemoveChildren();
        cm = GetComponent<CharacterManager>();
        gm = GetComponent<GameManager>();
        tm = GetComponent<TextManager>();
        lbm = GetComponent<LogButtonManager>();
        im = GetComponent<ImageManager>();
        stm = GetComponent<SceneTransitionManager>();
        StartStory();
    }

    // Creates a new Story object with the compiled story which we can then play! We also bind functions here.
    void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        BindExternalFunctions(story);
        RefreshView();
    }

    /* Call this to bind all ink functions to my scripts. Called in StartStory.
     */
    private void BindExternalFunctions(Story story)
    {
        story.BindExternalFunction("enter_both", (string leftname, string rightname) =>
        {
            cm.PlaceActors(leftname, rightname);
        });
        story.BindExternalFunction("enter_left", (string leftname) =>
        {
            cm.PlaceLeft(leftname);
        });
        story.BindExternalFunction("enter_right", (string rightname) =>
        {
            cm.PlaceRight(rightname);
        });
        story.BindExternalFunction("exit_left", () =>
        {
            cm.ExitLeft();
        });
        story.BindExternalFunction("exit_right", () =>
        {
            cm.ExitRight();
        });
        story.BindExternalFunction("enter_at_location", (string actorName, int location) =>
        {
            cm.PlaceAtLocation(actorName, location);
        });
        story.BindExternalFunction("remove  _all", () =>
        {
            cm.ExitAll();
        });
        story.BindExternalFunction("i_display_image", (string imageName) =>
        {
            im.DisplayImage(imageName);
        });
        story.BindExternalFunction("i_scene_transition", (string name) =>
        {
            stm.Transition(name);
        });
        story.BindExternalFunction("swap_actors", (string name, int position) =>
        {
            cm.SwapCharacterPosition(name, position);
        });
        story.BindExternalFunction("flip_actor", (string name) =>
        {
            cm.flip(name);
        });
    }

    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    /// <summary>
    /// @modifier John Angeles Called PlaceButtonFunction.
    /// </summary>
    void RefreshView()
    {
        // Remove all the UI on screen
        RemoveChildren();

        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            Button continueButton;

            // Well, first we need to check if there are any tags so we can make a function call, then display nothing.
            bool funcCall = CheckForImageFuncCall(text);

            if (funcCall)
            {
                return;
            }

            // Then, parse text so that we get the actor's name.
            string actorName = null;
            for (int i = 0; i < text.Length; i ++)
            {
                char currChar = text[i];
                if (currChar == ':')
                {
                    actorName = text.Substring(0, i);
                    text = text.Substring(i + 1);
                    break;
                }
            }

            // Lastly, get the emotion using story.currentTags.
            List<string> tags = story.currentTags;
            string emotion = null;
            if (tags.Count == 0)
            {
                emotion = "Neutral";
            }
            else
            {
                emotion = tags[0];
            }
            cm.manageTags(tags, actorName);

            // This removes any white space from the text.
            text = text.Trim();
            emotion = emotion.Trim();

            // Changes the actor's emotion!
            //cm.AutoPlaceActor(actorName);
            cm.changeActorEmotion(emotion, actorName);

            // Get the position of the person talking.
            int position = cm.GetPositionOfActor(actorName);

            // Display the text on screen!
            CreateContentView(text, actorName, position);

            // Added by @John Angeles. Creates a continue button. We can't refresh until we click continue.
            continueButton = AddContinueButton();
            return;
        }

        // Display all the choices, if there are any!
        // @modifier John Angeles Called PlaceButton here
        if (story.currentChoices.Count > 0)
        {
            int count = story.currentChoices.Count;
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                PlaceButton(button, i);
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate
                {
                    OnClickChoiceButton(choice);
                });
            }
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            Button choice = CreateChoiceView("End of story.\nRestart?");
            PlaceButton(choice, 0);
            choice.onClick.AddListener(delegate
            {
                cm.ExitAll();
                lbm.ResetLog();
                StartStory();
            });
        }
    }

    /* Given fresh text from the story, we can get check if the tag -i has been inputted.
     */
    private bool CheckForImageFuncCall(string freshText)
    {
        return freshText == "i\n";
    }

    public Button AddContinueButton()
    {
        Button continueButton = CreateChoiceView("Continue");
        PlaceButton(continueButton, 0);
        continueButton.onClick.AddListener(() => pressContinue());
        return continueButton;
    }

    /* We refresh after pressing continue.
     */
    private void pressContinue()
    {
        RefreshView();
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    /* Given a text and a position, creates content view so that we can see the text
     * displayed. Also takes in the actorName.
     */
    public void CreateContentView(string text, string actorName, int position)
    {
        if (text == "")
        {
            tm.ProcessText(null, 0, actorName);
            return;
        }
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = text;
        //storyText.transform.SetParent(canvas.transform, false);

        // Now, this next chunk of code positions the text properly.
        storyText.fontSize = 20;
        storyText.color = new Color(r, g, b);
        tm.ProcessText(storyText, position, actorName);
    }

    // Creates a button showing the choice text
    public Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(canvas.transform, false);

        // Gets the text from the button prefab
        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        // Make the button expand to fit the text
        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;

        return choice;
    }

    // Destroys all the children of this gameobject (all the UI)
    /// <summary>
    /// @modifier John Angeles: Removes all children unless it's the panel. We use 
    /// the panel for background images.
    /// 
    /// </summary>
    void RemoveChildren()
    {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            if (canvas.transform.GetChild(i).name == "Panel") {
                continue;
            }
            GameObject.Destroy(canvas.transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// Places the button. Helper specifically for RefreshView. Allows us to place our
    /// buttons correctly so that they don't overlap. Originally all of the 
    /// buttons would be instantiated so that they all overlap, but this function is created 
    /// specifically to fix that.
    /// </summary>
    /// <param name="button">Button.</param>
    /// <param name="index">Index.</param>
    public void PlaceButton(Button button, int index)
    {
        index++;
        button.transform.position = textBoxImage.transform.Find("Choice" + index).transform.position;
    }

    [SerializeField]
    private TextAsset inkJSONAsset;
    private Story story;

    [SerializeField]
    private Canvas canvas;

    // UI Prefabs
    [SerializeField]
    private Text textPrefab;
    [SerializeField]
    private Button buttonPrefab;
    CharacterManager cm;
    GameManager gm;
    TextManager tm;
    LogButtonManager lbm;
    ImageManager im;
    SceneTransitionManager stm;


    //Text position @adder John Angeles
    private Vector3 textBoxPosition = new Vector3(-300, -152, 0);

    //Text box
    public GameObject textBoxImage;

    //Colors
    private float r = 0.2f, g = 0.3f, b = 0.7f, a = 0.6f;

}
