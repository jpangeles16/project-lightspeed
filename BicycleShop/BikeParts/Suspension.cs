using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Don't know what this looks like irl.
 * @author John Angeles
 */
public class Suspension : MonoBehaviour
{
    private int _setting;

    public Suspension(int setting)
    {
        _setting = setting;
    }

    /* Returns our current setting.
     */
    public int GetSetting()
    {
        return _setting;
    }
}
