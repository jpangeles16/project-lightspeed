using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Set of headlights. Important for safety, of course!
 * @author John Angeles
 */
public class Headlight : MonoBehaviour
{

    private Lightbulb _lightbulb;
    private bool _isDamaged;

    //Creates a fully functioning headlight with a new fully functioning lightbulb.
    public Headlight()
    {
        _lightbulb = new Lightbulb();
        _isDamaged = false;
    }

    public void DamageHeadlight()
    {
        _isDamaged = true;
    }

    /* Uses up the battery on our lightbulb.
     */
    public void UseUpBattery()
    {
        _lightbulb.UseUpBattery();
    }

    /* Returns true if our lightbulb is still working.
     */
    public bool isDead()
    {
        return !_lightbulb.isFixed();
    }

    /* Returns true if I am damaged.
     */
    public bool isDamaged()
    {
        return _isDamaged;
    }


    public bool isFixed()
    {
        return _lightbulb.isFixed() && (!_isDamaged);
    }

    /* Replaces my lightbulb with LIGHTBULB.
     */
    public void ReplaceLightBulb(Lightbulb lightbulb)
    {
        _lightbulb = lightbulb;
    }
}
