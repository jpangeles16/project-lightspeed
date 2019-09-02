using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* @author John Angeles
 */
public class Exhaust : MonoBehaviour
{

    public bool _isBroken;

    /* Constructs a fully functioning exhaust.
     */
    public Exhaust()
    {
        _isBroken = false;
    }

    public bool IsBroken
	{
		get { return _isBroken; }
		set { _isBroken = value; }
	}
}
