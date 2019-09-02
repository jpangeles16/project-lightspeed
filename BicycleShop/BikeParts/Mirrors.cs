using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirrors : MonoBehaviour
{
    public bool _isCracked;
    public bool _isDirty;

    public Mirrors()
    {
        _isCracked = false;
        _isDirty = false;
    }

    public bool isFixed()
    {
        return (!_isCracked) && (!_isDirty);
    }

    public bool isDirty()
    {
        return _isDirty;
    }

    public bool isCracked()
    {
        return _isCracked;
    }

    /* What the name says. Smashes the mirror and makes it dirty.
     */
    public void smashMirror()
    {
        _isCracked = true;
        _isDirty = true;
    }

}
