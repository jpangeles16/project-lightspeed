using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Very important for a bike's safety.
 * @author John Angeles
 */
public class Brakes : MonoBehaviour
{

    private bool _isDamaged;

    /* Constucts fully functioning brakes.
     */
    public Brakes()
    {
        _isDamaged = false;
    }

    /* Constructs brakes. If isBroken is true, then our brakes are broken and need to be replaced.
     */
    public Brakes(bool isBroken)
    {
        _isDamaged = isBroken;
    }

    /* Makes me broken.
     */
    public void Brake()
    {
        _isDamaged = true;
    }

    /* Returns true if our brakes are fixed.
     */
    public bool IsFixed()
    {
        return !_isDamaged;
    }
} 
