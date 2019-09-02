using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handlebars.
 * @author John Angeles
 */
public class HandleBars : MonoBehaviour
{

    private int _position;

    /* Constructs some handlebars with position POSITION.
     */
    public HandleBars(int position)
    {
        if (position > 10 || position < 0) {
            throw new System.Exception("Position out of bounds!");
        }
        _position = position;
    }

    /* Rises position up by one.
     */
    public void Rise()
    {
        if (_position < 10)
        {
            _position++;
        }
    }

    public void Lower()
    {
        if (_position > 0)
        {
            _position--;
        }
    }

    public int Position()
    {
        return _position;
    }

}
