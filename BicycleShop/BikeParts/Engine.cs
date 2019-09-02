using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* The engine. Very important indeed.
 * @author John Angeles
 */
public class Engine : MonoBehaviour
{

    private Sparkplugs _sparkplugs;

    private Clutch _clutch;

    private Oil _oil;

    /* Constructs an engine given the sparkplugs and the clutch.
     */
    public Engine(Sparkplugs sparkplugs, Clutch clutch, Oil oil)
    {
        _sparkplugs = sparkplugs;
        _clutch = clutch;
    }

    /* Getter/setter for sparkplugs.
     */
    public Sparkplugs Sparkplugs
    {
        get { return _sparkplugs; }
        set { _sparkplugs = value; }
    }

    /* Getter/setter for clutch.
     */
    public Clutch Clutch
    {
        get { return _clutch; }
        set { _clutch = value; }
    }

    /* Getter/setter for oil.
     */
     public Oil Oil
    {
        get { return _oil; }
        set { _oil = value; }
    }

    /* True if the clutch is damaged.
     */
    public bool ClutchIsDamaged()
    {
        return !_clutch.isFixed();
    }

    /* True if sparkplugs are damaged.
     */
    public bool SparkplugsIsDamaged()
    {
        return !_sparkplugs.IsFixed();
    }

    public int OilLevel()
    {
        return _oil.Level;
    }

    public int OilCondition()
    {
        return _oil.Condition;
    }

    public int OilType()
    {
        return _oil.Type;
    }

  
}
