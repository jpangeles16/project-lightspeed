using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A bicycle. To construct one, we're gonna need a lot of parts.
 * @author John Angeles
 */
public class Bicycle : MonoBehaviour
{
    [SerializeField]
    private GameObject _brakes;
    [SerializeField]
    private GameObject _chain;
    [SerializeField]
    private GameObject _clutch;
    [SerializeField]
    private GameObject _engine;
    [SerializeField]
    private GameObject _exhaust;
    [SerializeField]
    private GameObject _handlebars;
    [SerializeField]
    private GameObject _headlight;
    [SerializeField]
    private GameObject _lightbulb;
    [SerializeField]
    private GameObject _leftMirror;
    [SerializeField]
    private GameObject _rightMirror;
    [SerializeField]
    private GameObject _oil;
    [SerializeField]
    private GameObject _radiator;
    [SerializeField]
    private GameObject _sparkplugs;
    [SerializeField]
    private GameObject _suspension;
    [SerializeField]
    private GameObject _backWheel;
    [SerializeField]
    private GameObject _frontWheel;

    /* Constructor for bike that takes a lot of parts to construct.
     */
    public Bicycle(
        GameObject brakes,
        GameObject chain,
        GameObject clutch,
        GameObject engine,
        GameObject exhaust,
        GameObject handlebars,
        GameObject headlight,
        GameObject lightbulb,
        GameObject leftMirror,
        GameObject rightMirror,
        GameObject oil,
        GameObject radiator,
        GameObject sparkplugs,
        GameObject suspension,
        GameObject backWheel,
        GameObject frontWheel
    )
    {
        _brakes = brakes;
        _chain = chain;
        _clutch = clutch;
        _engine = engine;
        _exhaust = exhaust;
        _handlebars = handlebars;
        _headlight = headlight;
        _lightbulb = lightbulb;
        _leftMirror = leftMirror;
        _rightMirror = rightMirror;
        _oil = oil;
        _radiator = radiator;
        _sparkplugs = sparkplugs;
        _suspension = suspension;
        _backWheel = backWheel;
        _frontWheel = frontWheel;
    }
}
 