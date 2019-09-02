using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

/* The script that controlls all of the Actors.
 * Imagine this script as the director of the show, and is 
 * in charge of placing the actors as well as changing
 * their emotions.
 * We also handle indentifying tags here.
 * @author John Angeles
 */
public class CharacterManager : MonoBehaviour
{   
    /// <summary>
    /// The ink manager that is attatched to this scipt's gameObject.
    /// </summary>
    private InkManager _inkManager;

    /// <summary>
    /// The story.
    /// </summary>
    private Story story;

    /* A list of characters. Kind of still don't know what this means.
     */
    public GameObject[] characters;

    /* All actors that have been instantiated. Assume that the Start function
     * has been called and that this list contains a bunch of actors from
     * the characters field.
     */
    [HideInInspector]
    public List<GameObject> actorsList = new List<GameObject>();

    /* The actors that are active.
     */
    public List<Actor> activeActors = new List<Actor>();

    /* 2D - vector that contain the rotation of our right actor.
     */
    private Vector3 rightActorRotation = new Vector3(0, 180, 0);

    /// <summary>
    /// The positions of our left and right actors. Just make sure to 
    /// use their transform and position fields.
    /// </summary>
    public GameObject _leftCenterActorPosition;
    public GameObject _leftSideActorPosition;
    public GameObject _leftBackActorPosition;
    public GameObject _rightCenterActorPosition;
    public GameObject _rightSideActorPosition;
    public GameObject _rightBackActorPosition;

    /* Set of valid characterTags.
     */
    private CharacterTags characterTags;

    /* Works as follows...
     * We iterate through the entire loop of characters, and for each character,
     * we are going to create an instance of it, set it to inactive, name it properly,
     * and then add it to our list of all actors called actorsList.
     */
    void Awake()
    {
        _inkManager = GetComponent<InkManager>();

        for (int i = 0; i < characters.Length; i++)
        {
            GameObject newActor = Instantiate(characters[i]);
            newActor.SetActive(false);
            newActor.name = characters[i].name;
            actorsList.Add(newActor);
        }
        characterTags = GetComponent<CharacterTags>();
    }

    /* Flips an actor.
     */
    public void flip(string actorName) {
        Actor toFlip = FetchActor(actorName);
        toFlip.transform.Rotate(0, 180, 0);
    }

    /* Assumes that the argument we pass in is from story.currentTags.
     * This function basically handles all of the tag managing, so that our character can change emotions
     * and their reaction icon.
     * We also pass in an actorName to find out the proper emotion
     */
    public void manageTags(List<string> tags, string actorName)
    {
        foreach (string tag in tags)
        {
            if (characterTags.IsReaction(tag))
            {
                setReactionIcon(tag, actorName);
            }
        }
    }

    /* Given an actor whose name is actorName, set that actor's reactionIcon to REACTIONICON.
   */
    private void setReactionIcon(string reactionIcon, string actorName)
    {
        Vector3 actorPosition = FetchActor(actorName).transform.position;
        foreach (GameObject sprite in characterTags.getReactionIcons())
        {
            if (sprite.name == reactionIcon)
            {
                GameObject toPlace = Instantiate(sprite) as GameObject;
                toPlace.transform.position = actorPosition;
                CharacterTags.RepositionTag(toPlace);
            }
        }
    }



    /* Moves the actor whose name is name to position POSITION. Assumes that actor whos name is NAME has been placed already.
     * Runtime is O(size of actor list).
     */
    public void SwapCharacterPosition(string name, int position)
    {
        bool alreadyActorAtPosition = hasActorAtPosition(position);
        if (alreadyActorAtPosition)
        {
            Actor toMoveToOld = FetchActor(position);
            Actor toMoveToNew = FetchActor(name);
            // Place actor at new location to old.
            PlaceAtLocation(toMoveToOld.name, toMoveToNew.id);
            PlaceAtLocation(name, position);
        } else
        {
            PlaceAtLocation(name, position);
        }
    }

    /* Helper for swapCharacterPosition. If there is an actor at position POSITION, this
     * returns true.
     */
    private bool hasActorAtPosition(int position)
    {
        foreach (Actor actor in activeActors)
        {
            if (actor.id == position)
            {
                return true;
            }
        }
        return false;
    }

    /* Helper for swapCharacterPosition. Returns a pointer to the actor who is at position POSITION.
     * Returns null if there is no actor there.
     */
     private Actor FetchActor(int position)
    {
        foreach (Actor actor in activeActors)
        {
            if (actor.id == position)
            {
                return actor;
            }
        }
        return null;
    }

    /* Helper for swapCharacterPosition. Returns pointer to actor whose name is NAME.
     */
    private Actor FetchActor(string name)
    {
        foreach (Actor actor in activeActors)
        {
            if (actor.name.Equals(name))
            {
                return actor;
            }
        }
        return null;
    }
   

    /// <summary>
    /// Places actors based off of how many active actors there are.
    /// Also places the actor whose name is NAME accordingly.
    /// </summary>
    public void AutoPlaceActor(string actorToPlace)
    {
        foreach (Actor actor in activeActors)
        {
            if (actor.name == actorToPlace)
            {
                return;
            }
        }

        // Now assumes actor hasn't been placed yet.

        if(activeActors.Count >= 2)
        {
            return;
        }

        if (activeActors.Count == 0)
        {
            PlaceLeft(actorToPlace);
        }
        else
        {
            PlaceRight(actorToPlace);
        }
    }

    /* Iterates through the actorsList, and places LEFTACTORNAME to the
     * left of our screen, and RIGHTACTORNAME to the right of our screen.
     * Runtime should be O(size of actorsList), so it's decently efficient.
     */
    public void PlaceActors(string leftActorName, string rightActorName)
    {
        foreach (GameObject g0 in actorsList)
        {
            if (g0.name == leftActorName)
            {
                g0.GetComponent<Actor>().id = 0;
                g0.SetActive(true);
                activeActors.Add(g0.GetComponent<Actor>());
                g0.transform.position = _leftCenterActorPosition.transform.position;
                g0.transform.localScale = _leftCenterActorPosition.transform.localScale;
            }
            else if (g0.name == rightActorName)
            {
                g0.GetComponent<Actor>().id = 1;
                g0.SetActive(true);
                activeActors.Add(g0.GetComponent<Actor>());
                g0.transform.position = _rightCenterActorPosition.transform.position;
                g0.transform.localEulerAngles = rightActorRotation;
                g0.transform.localScale = _rightCenterActorPosition.transform.localScale;
            }
        }
    }

    /// <summary>
    /// Places only the left actor. If there is an actor already placed, then we must replace the actor.
    /// </summary>
    /// <param name="leftActorName">Left actor name.</param>
    public void PlaceLeft(string leftActorName)
    {
        foreach (GameObject g0 in actorsList)
        {
            if (g0.name == leftActorName)
            {
                g0.GetComponent<Actor>().id = 0;
                g0.SetActive(true);
                activeActors.Add(g0.GetComponent<Actor>());
                g0.transform.position = _leftCenterActorPosition.transform.position;
                g0.transform.localScale = _leftCenterActorPosition.transform.localScale;
            }
        }
    }

    /// <summary>
    /// Places only the right actor. If there is an actor already placed, then we must replace the actor.
    /// </summary>
    /// <param name="rightActorName">Left actor name.</param>
    public void PlaceRight(string rightActorName)
    {
        foreach (GameObject g0 in actorsList)
        {
            if (g0.name == rightActorName)
            {
                g0.GetComponent<Actor>().id = 1;
                g0.SetActive(true);
                activeActors.Add(g0.GetComponent<Actor>());
                g0.transform.position = _rightCenterActorPosition.transform.position;
                g0.transform.localEulerAngles = rightActorRotation;
                g0.transform.localScale = _rightCenterActorPosition.transform.localScale;
            }
        }
    }

    /// <summary>
    /// Assumes that we have no actor placed on POSITION.
    /// Places the actor at position POSITION. 0 = leftcenter, 1 = rightcenter, 2 = leftside, 3 = rightside, 4 = leftback, 5 = rightback
    /// </summary>
    /// <param name="actorName">Actor name.</param>
    /// <param name="location">Location.</param>
    public void PlaceAtLocation(string actorName, int location)
    {
        if (location == 0)
        {
            PlaceLeft(actorName);
        }
        else if (location == 1)
        {
            PlaceRight(actorName);
        }
        else
        {
            // Although chunky, this for-loop just gets the right actor and places it accordingly.
            foreach (GameObject g0 in actorsList)
            {
                if (g0.name == actorName)
                {
                    g0.GetComponent<Actor>().id = location;
                    g0.SetActive(true);
                    activeActors.Add(g0.GetComponent<Actor>());

                    // More conditionals to place the actor correctly!

                    if (location == 2)
                    {
                        g0.transform.position = _leftSideActorPosition.transform.position;
                        g0.transform.localScale = _leftSideActorPosition.transform.localScale;
                    }
                    else if (location == 3)
                    {
                        g0.transform.position = _rightSideActorPosition.transform.position;
                        g0.transform.localScale = _rightSideActorPosition.transform.localScale;
                        g0.transform.localEulerAngles = rightActorRotation;
                    }
                    else if (location == 4)
                    {
                        g0.transform.position = _leftBackActorPosition.transform.position;
                        g0.transform.localScale = _leftBackActorPosition.transform.localScale;
                    }
                    else
                    {
                        g0.transform.position = _rightBackActorPosition.transform.position;
                        g0.transform.localScale = _rightBackActorPosition.transform.localScale;
                        g0.transform.localEulerAngles = rightActorRotation;
                    }
                }
            }
        }

    }

    public void ExitAll()
    {
        foreach (Actor actor in activeActors)
        {
            actor.gameObject.SetActive(false);
        }
        activeActors.Clear();
    }

    /// <summary>
    /// Actor on stage right will exit.
    /// </summary>
    public void ExitLeft()
    {
        Actor toRemove = null;
        foreach (Actor actor in activeActors)
        {
            if (actor.GetComponent<Actor>().id == 0)
            {
                actor.gameObject.SetActive(false);
                toRemove = actor;
            }
        }
        if (toRemove == null)
        {
            Debug.Log("No left actor placed!");
            return;
        }
        activeActors.Remove(toRemove);
    }

    /// <summary>
    /// Actor on stage right will exit.
    /// </summary>
    public void ExitRight()
    {
        Actor toRemove = null;
        foreach (Actor actor in activeActors)
        {
            if (actor.GetComponent<Actor>().id == 1)
            {
                actor.gameObject.SetActive(false);
                toRemove = actor;
            }
        }
        if (toRemove == null)
        {
            Debug.Log("No right actor placed!");
            return;
        }
        activeActors.Remove(toRemove);
    }



    /// <summary>
    /// Changes the actor whose name is ACTORNAME to EMOTION.
    /// </summary>
    /// <param name="emotion">Emotion.</param>
    /// <param name="actor">Actor.</param>
    public void changeActorEmotion(string emotion, string actorName)
    {
        foreach (Actor actor in activeActors)
        {
            if (actor.name == actorName)
            {
                changeActorEmotion(emotion, actor.id);
                return;
            }
        }
    }

    /* Changes the actor whose id is ID to EMOTION.
     */
    public void changeActorEmotion(string emotion, int id)
    {
        foreach (Actor actor in activeActors)
        {
            if (actor.gameObject.activeInHierarchy)
            {
                if (actor.id == id)
                {
                    actor.ChangeState(emotion);
                    return;
                }
            }
        }
    }

    /// <summary>
    /// Gets the position of the active actor whose name is ACTORNAME. Returns 7 if nothing has been returned
    /// </summary>
    /// <returns>The position of actor.</returns>
    /// <param name="actorName">Actor name.</param>
    public int GetPositionOfActor(string actorName)
    {
        foreach (Actor actor in activeActors)
        {
            if (actor.name == actorName)
            {
                return actor.id;
            }
        }
        return 7;
    }

    

}
