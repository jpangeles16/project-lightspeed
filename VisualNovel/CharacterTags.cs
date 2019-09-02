using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Class devoted to having a bunch of enums so we can identify each tag.
 * Be sure to call RepositionTag to reposition tags each time they're placed.
 * @author John Angeles
 */
public class CharacterTags : MonoBehaviour
{

    /* Repositions tag properly, assuming that it has been placed by 
     */
    public static void RepositionTag(GameObject tag)
    {
        tag.transform.position += new Vector3(100, 50, -1);
    }

    /* The list of reactionIcons. Make sure their names match the ones listed in reactionIcons!
     */
    public GameObject[] reactionIcons;

    /* Returns true if tag is a reactionIcon. Runtime is linear with respect to the size of 
     */
    public bool IsReaction(string tag)
    {
        foreach (string reactionIcon in System.Enum.GetNames(typeof(ReactionIcons)))
        {
            if (reactionIcon.Equals(tag))
            {
                return true;
            }
            
        }
        return false;
    }

    public enum ReactionIcons
    {
        ExclamationPoint
    }

    public GameObject[] getReactionIcons()
    {
        return this.reactionIcons;
    }

}
