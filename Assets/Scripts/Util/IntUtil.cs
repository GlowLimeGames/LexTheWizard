// Author: Isaiah Mann
// Description: Static helper class used to speed to speedup simple integer operations

public static class IntUtil {

	// Min is inclusive, max is exclusive
	public static bool InRange (int target, int max, int min = 0) {
		return min <= target && target < max;
	}

	public static int ParseObj (object obj) {
		return int.Parse(obj.ToString());
	}
}
