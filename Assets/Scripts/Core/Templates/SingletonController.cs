using UnityEngine;
using System.Collections;
using System.Reflection;

public class SingletonController<T> : Controller where T : class {
	public static T Instance;
	protected bool dontDestroyOnLoad = false;
	protected override void SetReferences () {
		if (tryInit(ref Instance, this as T, gameObject, dontDestroyOnLoad)) {
			base.SetReferences ();
		}
	}

	protected override void CleanupReferences () {
		base.CleanupReferences ();
		tryCleanupSingleton(ref Instance, this as T);
	}

	bool tryInit (ref T singleton, T instance, GameObject gameObject, bool dontDestroyOnLoad = false) {
		if (singleton == null) {
			singleton = instance;
			if (dontDestroyOnLoad) {
				Object.DontDestroyOnLoad(gameObject);
			}
			return true;
		} else {
			Object.Destroy(gameObject);
			return false;
		}
	}

	bool tryCleanupSingleton (ref T singleton, T instance) {
		if (singleton == instance) {
			singleton = default(T);
			return true;
		} else {
			return false;
		}
	}
}
