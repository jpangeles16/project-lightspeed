using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* These belong to the engine.
 * @author John Angeles
 */
public class Sparkplugs : MonoBehaviour
{
    private bool _isBroken;

    /* Constructs fully functioning sparkplugs.
     */
    public Sparkplugs()
    {
        _isBroken = false;
    }

    public bool IsBroken
    {
        get { return _isBroken; }
        set { _isBroken = value; }
    }

    public bool IsFixed()
    {
        return !_isBroken;
    }
}
