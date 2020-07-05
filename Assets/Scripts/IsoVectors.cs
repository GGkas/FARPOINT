using UnityEngine;

//Generic class for Isometric direction vectors (N, NW, W, SW, S, SE, E, NE)
public class IsoVectors
{
    private Vector2 _NVec;
    private Vector2 _NEVec;
    private Vector2 _NWVec;
    private Vector2 _SVec;
    private Vector2 _SEVec;
    private Vector2 _SWVec;
    private Vector2 _EVec;
    private Vector2 _WVec;

    public IsoVectors()
    {
        _NVec = Vector2.up;
        _NEVec = new Vector2(Mathf.Cos(45.0f), Mathf.Sin(45.0f));
        _NWVec = new Vector2(-_NEVec.x, _NEVec.y);
        _SVec = Vector2.down;
        _SEVec = new Vector2(_NEVec.x, -_NEVec.y);
        _SWVec = new Vector2(-_NEVec.x, -_NEVec.y);
        _EVec = Vector2.right;
        _WVec = Vector2.left;
    }

    public Vector2 NVec
    {
        get { return _NVec; }
        set
        {
            _NVec.x = value.x;
            _NVec.y = value.y;
        }
    }
    public Vector2 SVec
    {
        get { return _SVec; }
        set
        {
            _SVec.x = value.x;
            _SVec.y = value.y;
        }
    }
    public Vector2 EVec
    {
        get { return _EVec; }
        set
        {
            _EVec.x = value.x;
            _EVec.y = value.y;
        }
    }
    public Vector2 WVec
    {
        get { return _WVec; }
        set
        {
            _WVec.x = value.x;
            _WVec.y = value.y;
        }
    }
    public Vector2 NEVec
    {
        get { return _NEVec; }
        set
        {
            _NEVec.x = value.x;
            _NEVec.y = value.y;
        }
    }
    public Vector2 NWVec
    {
        get { return _NWVec; }
        set
        {
            _NWVec.x = value.x;
            _NWVec.y = value.y;
        }
    }
    public Vector2 SEVec
    {
        get { return _SEVec; }
        set
        {
            _SEVec.x = value.x;
            _SEVec.y = value.y;
        }
    }
    public Vector2 SWVec
    {
        get { return _SWVec; }
        set
        {
            _SWVec.x = value.x;
            _SWVec.y = value.y;
        }
    }

}
