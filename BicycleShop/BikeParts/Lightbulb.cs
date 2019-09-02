using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Let 'er shine.
 * @John Angeles
 */
public class Lightbulb : MonoBehaviour
{

    private bool _isDead;

    /* Constructs a fully functioning lightbulb.
     */
    public Lightbulb()
    {
        _isDead = false;
    }

    /* After calling this I will be a dead lightbulb. Stop wasting energy!
     */
    public void UseUpBattery()
    {
        _isDead = true;
    }

    public bool isFixed()
    {
        return !_isDead;
    }
}
