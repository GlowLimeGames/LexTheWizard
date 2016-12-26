using UnityEngine;

public static class CameraUtil {

	public static Vector3 ScreenToWorldPosition (Vector3 screenPosition, float zOffset = 0) {
		screenPosition.z = screenPosition.z - Camera.main.transform.position.z + zOffset;
		screenPosition = Camera.main.ScreenToWorldPoint(screenPosition);
		return screenPosition;
	}

}
