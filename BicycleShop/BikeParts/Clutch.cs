using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* I have no idea what this looks like visually.
 * @author John Angeles
 */
public class Clutch : MonoBehaviour
{
    private bool _isDamaged;

    /* Constructs a fully functional clutch.
     */
    public Clutch()
    {
        _isDamaged = false;
    }

    public void damageClutch()
    {
        _isDamaged = true;
    }

    public bool isFixed()
    {
        return !_isDamaged;
    }

}
