/*
 * Author: Isaiah Mann
 * Descriptioin: Generic class to represent serialized data (works in tandem with JsonUtility to load an array of serialized instances)
 */

[System.Serializable]
public class SerializableDataCollection<T> {

	public T[] Elements;
	public int Count {
		get {
			return Elements.Length;
		}
	}
	public T this[int index] {
		get {
			if (index >= 0 && index < Count) {
				return Elements[index];
			} else {
				return default(T);
			}
		}
	}
}
