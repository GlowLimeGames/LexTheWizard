/*
 * Author(s): Isaiah Mann 
 * Description: Helper class to assist with Singleton implementation
 */


using UnityEngine;
using System.Collections;

public static class SingletonUtil {

	public static bool TryInit<T> (ref T singleton, T instance, GameObject gameObject) {
		if (singleton == null) {
			singleton = instance;
			Object.DontDestroyOnLoad(gameObject);
			return true;
		} else {
			Object.Destroy(gameObject);
			return false;
		}
	}
}
