using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Oil that's needed for the constructor of Engine.
 * @author John Angeles
 */
public class Oil : MonoBehaviour
{

    public int _level;

    public int _condition;

    public int _type;

    /* Constructs an oil with a certain level, condition, and type.
     */
    public Oil (int level, int condition, int type)
    {
        Debug.Assert(10 >= level && level >= 0);
        Debug.Assert(10 >= condition && condition >= 0);
        Debug.Assert(4 >= type && type >= 0);
        _level = level;
        _condition = condition;
        _type = type;
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public int Condition
    {
        get { return _condition; }
        set { _condition = value; }
    }

    public int Type
    {
        get { return _type; }
        set { _type = value; }
    }
}
