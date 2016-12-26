/*
 * Author: Isaiah Mann
 * Description Used to reason about directions
 */

using UnityEngine;

public static class DirectionUtil {
	public static Vector2 VectorFromDirection (Direction direction) {
		switch(direction) {
		case Direction.West:
			return Vector2.left;
		case Direction.East:
			return Vector2.right;
		case Direction.North:
			return Vector2.up;
		case Direction.South:
			return Vector2.down;
		default:
			return Vector2.zero;
		}
	}

	public static Direction Clockwise90Degrees (Direction direction) {
		switch(direction) {
		case Direction.West:
			return Direction.North;
		case Direction.East:
			return Direction.South;
		case Direction.North:
			return Direction.East;
		case Direction.South:
			return Direction.West;
		default:
			return default(Direction);
		}
	}

	public static Vector2 Clockwise90DegreesVector (Direction direction) {
		return VectorFromDirection(Clockwise90Degrees(direction));
	}

	public static Vector2 ShiftPerpendicular (Direction direction, bool isClockwise = true) {
		return VectorFromDirection(PerpendicularDirection(direction, isClockwise));
	}

	public static Direction PerpendicularDirection (Direction direction, bool isClockwise = true) {
		if (direction == Direction.South) {
			return isClockwise ? Direction.West : Direction.East;
		} else if (direction == Direction.North) {
			return isClockwise ? Direction.East : Direction.West;
		} else if (direction == Direction.West) {
			return isClockwise ? Direction.North : Direction.South;
		} else if (direction == Direction.East) {
			return isClockwise ? Direction.South : Direction.North;
		} else {
			return default(Direction);
		}
	}
		
	public static Direction OppositeDirection (Direction direction) {
		int directionIndex = (int) direction;
		int directionCount = System.Enum.GetNames(typeof(Direction)).Length;
		int oppositeDirectionDifference = directionCount/2;
		directionIndex += oppositeDirectionDifference;
		directionIndex %= directionCount;
		return (Direction) directionIndex;
	}

	public static int DegreesToRotate (Direction fromDirection, Direction toDirection) {
		int degreeStep = 90;
		int degrees = 0;
		int currentDirectionIndex = (int) fromDirection;
		int numDirections = System.Enum.GetNames(typeof(Direction)).Length;
		while (currentDirectionIndex != (int) toDirection) {
			currentDirectionIndex ++;
			degrees += degreeStep;
			currentDirectionIndex %= numDirections;
		}
		return degrees;
	}
}