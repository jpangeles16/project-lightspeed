using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* I have no idea what this looks like in a bike.
 * @author John Angeles
 */
public class Radiator : MonoBehaviour
{

    private bool _isLeaking;
       
    /* Constructs a fully functioning radiator.
     */
    public Radiator()
    {
        _isLeaking = false;
    }

    /* If true, we construct a broken radiator.
     */
     public void FixRadiator()
    {
        _isLeaking = false;
    }

    /* Causes the radiator to leak.
     */
    public void CauseLeak()
    {
        _isLeaking = true;
    }

    /* Returns true if I am leaking.
     */
    public bool IsLeaking()
    {
        return _isLeaking;
    }

    /* Returns true if I am fixed.
     */
    public bool IsFixed()
    {
        return !IsLeaking();
    }

}
