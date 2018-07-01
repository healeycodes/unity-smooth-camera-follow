## Smooth Camera Follow

Written in C#. Designed for an RTS style camera. With smooth follow (X-,Y-,and Z-axis), and smooth rotate as well. Smooth meaning linear interpolation. Great for a quick game jam camera.


Variables to experiment with:

```C#
public Transform player;
public float moveSmoothTime = 1f; // Lower is slower
public float heightSmoothTime = 1f; // Lower is slower
public float rotationSmoothTime = 0.1f; // Lower is slower
public float followBehindDst = 5f;
public float lookThisFarInFront = 5f;
public float height = 12f;
```

### Setup

Set the object's Transform that you wish to follow to `player`.

The camera will look at a point on the positive Z-axis from the object.

Personally, I like to negatively lerp the `followBehindDst` and `height` values upon player death.

### License

https://mit-license.org/
