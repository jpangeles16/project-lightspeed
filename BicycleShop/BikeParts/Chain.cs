using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{

    private int _condition, _tension;

    /* Constructs a chain with a condition, and a certain tension.
     * Condition must be between 1 to 5, while tension must be between
     * 10 to 30.
     */
    public Chain(int condition, int tension)
    {
        Debug.Assert(condition >= 1 && condition <= 5);
        Debug.Assert(tension >= 10 && tension <= 30);
        _condition = condition;
        _tension = tension;
    }

    public int Tension
    {
        get
        {
            return _tension;
        } set
        {
            _tension = value;
        }
    }

    public int Condition
    {
        get { return _condition; }
        set { _condition = value; }
    }

    public bool IsBadCondition()
    {
        return _condition == 1 || _condition == 2;
    }
}
