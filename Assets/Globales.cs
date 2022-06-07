using UnityEngine;

public static class Globales
{
    public static Vector3 North = Vector3.forward;
    public static Vector3 East = Vector3.right;
    public static Vector3 South = -Vector3.forward;
    public static Vector3 West = -Vector3.right;
    public static Vector3 NorthEast = Vector3.forward + Vector3.right;
    public static Vector3 SouthEast = -Vector3.forward + Vector3.right;
    public static Vector3 SouthWest = -Vector3.forward - Vector3.right;
    public static Vector3 NorthWest = Vector3.forward - Vector3.right;
    public static Vector3 Up = Vector3.up;

    public static Vector3 ConvertDirectionToVector(Direction dir)
    {
        if (dir == Direction.North)
            return North;
        if (dir == Direction.West)
            return West;
        if (dir == Direction.East)
            return East;
        if (dir == Direction.South)
            return South;
        if (dir == Direction.NorthEast)
            return NorthEast;
        if (dir == Direction.SouthEast)
            return SouthEast;
        if (dir == Direction.SouthWest)
            return SouthWest;
        if (dir == Direction.NorthWest)
            return NorthWest;
        else
            return Up;
    }

    public static Direction InWhichDirectionIs(GameObject check, GameObject me)
    {
        Vector3 dir = check.transform.position - me.transform.position;
        if (dir == North)
            return Direction.North;
        if (dir == East)
            return Direction.East;
        if (dir == South)
            return Direction.South;
        if (dir == West)
            return Direction.West;
        if (dir == NorthEast)
            return Direction.NorthEast;
        if (dir == NorthWest)
            return Direction.NorthWest;
        if (dir == SouthEast)
            return Direction.SouthEast;
        if (dir == SouthWest)
            return Direction.SouthWest;
        if (dir == Up)
            return Direction.Up;
        else return Direction.Up;
    }
}
