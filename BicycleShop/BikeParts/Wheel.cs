using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A simple wheel. Can be left or right.
 * Assume that everything we do here will fix the wheel. For example,
 * if we call pumpAir, assume that Hyde already spent the proper materials
 * in order to pump the air into the wheel.
 * @author John Angeles
 */
public class Wheel : MonoBehaviour
{

    // Recommended lower and upper bound for the psi.
    private int _lowerBoundPSI, _upperBoundPSI;

    // Current psi.
    private int _currPSI;

    //True if our tire is popped.
    private bool _isPopped;

    //Constructs a totally functional wheel with no threshold for necessary tire pressure, and a default PSI of 20.
    public Wheel()
    {
        _lowerBoundPSI = 0;
        _upperBoundPSI = 40;
        _isPopped = false;
        _currPSI = 20;
    }

    /* Constructs a fully functioning wheel with a lowerbound PSI and a higherbound PSI. PSI is default to be in the middle
     * of lower and upper bound psis.
     */
    public Wheel(int lowerBoundPSI, int upperBoundPSI)
    {
        Debug.Assert(lowerBoundPSI >= 0 && upperBoundPSI <= 40);
        _lowerBoundPSI = lowerBoundPSI;
        _upperBoundPSI = upperBoundPSI;
        _isPopped = false;
        _currPSI = (_lowerBoundPSI + _upperBoundPSI) / 2;
    }

    public int LowerBoundPSI()
    {
        return _lowerBoundPSI;
    }

    public int UpperBoundPSI()
    {
        return _upperBoundPSI;
    }

    public int GetPSI()
    {
        return _currPSI;
    }

    /* Boring way to set the psi to be some value PSI.
     */
    public void SetPSI(int psi)
    {
        _currPSI = psi;
    }

    /* Pops the wheel and sets the PSI to 0.
     */
    public void Pop()
    {
        _isPopped = true;
        _currPSI = 0;
    }

    public bool IsPopped()
    {
        return _isPopped;
    }

    // Returns true if psi is below the lower bound
    public bool IsFlat()
    {
        if (_isPopped)
        {
            return true;
        }
        return _currPSI < _lowerBoundPSI;
    }

    /* Increases the PSI by 5. We can never go over a PSI of 40.
     */
    public void PumpTire()
    {
        if (_currPSI >= 35)
        {
            _currPSI = 40;
        } else
        {
            _currPSI += 5;
        }
    }

    public bool IsFixed()
    {
        return !IsPopped() && !IsFlat();
    }

}
