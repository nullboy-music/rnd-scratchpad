using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ElementalPoint
{
    public ElementalPoint(int X, int Y, int Z, int CullingValue){
        x = X;
        y = Y;
        z = Z;
        cullingValue = CullingValue;
    }

    public readonly int x { get; }
    public readonly int y { get; }
    public readonly int z { get; }
    public readonly int cullingValue { get; }
}
