using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Actor class that represents an actor inside the game. Still trying to comprehend
 * what this means, but bear with me for now.
 * An actor is a game object/prefab that contains its own ID, its own set of sprites that
 * represent its emotions, as well as other useful functions for changing its emotions.
 * @author John Angeles
 */
public class Actor : MonoBehaviour
{

    /* My ID. Generalized now to a generic actor position.
     */
    public int id;

    [Tooltip("Put down happy, sad, neutral, and angry in those orders.")]
    /* Still trying to comprehend what this means...
     * I think that emotionSprites[0] will contain a happy sprite,
     * then emotionSprites[1] will contain a sad sprite, and so on.
     * Look at the enum characterEmotion in this class.
     */    
    public Sprite[] emotionSprites;

    /* I don't know what a sprite renderer is.
     */
    SpriteRenderer spRend;    

    /* A set of valid character emotions - as the name implies, what I am currently feeling right
     * now. Feel free to add more!
     */
    public enum CharacterEmotion
    {
        happy, sad, neutral, angry
    }

    /* The actual emtion that I feel. 
     */   
    [SerializeField]
    [Tooltip("Input the actor's feelings here")]
    CharacterEmotion myState;

    /* As soon as start is called, I have a neutral state.
     */   
    void Start()
    {
        myState = CharacterEmotion.neutral;
        spRend = GetComponent<SpriteRenderer>();
    }

    /* Changes my emotion to emotioName
     */    
   public void ChangeState(string emotionName)
    {
        char[] emotionNameAsCharArray = emotionName.ToCharArray();
        emotionNameAsCharArray[0] = char.ToUpper(emotionName[0]);
        emotionName = new string(emotionNameAsCharArray);
        StartCoroutine(emotionName + "State");
    }

    /* Changes the sprite to happy. Called by ChangeState.
     */   
    IEnumerator HappyState()
    {
        GetComponent<SpriteRenderer>().sprite = emotionSprites[0];
        yield return null;
    }

    /* Changes the sprite to sad.
     */   
    IEnumerator SadState()
    {
        GetComponent<SpriteRenderer>().sprite = emotionSprites[1];
        yield return null;
    }

    /* Changes the sprite to neutral.
    */
    IEnumerator NeutralState()
    {
        GetComponent<SpriteRenderer>().sprite = emotionSprites[2];
        yield return null;
    }

    /* Changes the sprite to angry.
    */
    IEnumerator AngryState()
    {
        GetComponent<SpriteRenderer>().sprite = emotionSprites[3];
        yield return null;
    }

}
