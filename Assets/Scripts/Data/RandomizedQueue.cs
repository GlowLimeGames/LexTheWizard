/*
 * Author: Isaiah Mann
 * Description: A queue that returns a random element
 */

using UnityEngine;
using System.Collections.Generic;

public class RandomizedQueue<T> {

	public int Count {
		get {
			return _data.Count;
		}
	}

	// Uses list as internal data structure
	List<T> _data = new List<T>();

	// Tracks the most recent element removed from the queue
	T _mostRecentRemoved;

	public RandomizedQueue () {

	}

	// Can create a queue prepopulated with an arbitrary amount of elements
	public RandomizedQueue (params T[] data) {

		for (int i = 0; i < data.Length; i++) {
			Enqueue(data[i]);
		}

	}

	public void Enqueue (T value) {

		_data.Add(value);

	}

	public T Dequeue (bool dontReturnMostRecent = false) {

		T elementToReturn = randomElement();

		if (dontReturnMostRecent && canReturnNonMostRecentItem()) {

			while (isMostRecent(elementToReturn)) {
				elementToReturn = randomElement();
			}

		}

		_data.Remove(elementToReturn);

		_mostRecentRemoved = elementToReturn;

		return elementToReturn;
	}

	// Removes an element and re-adds it to the queue (will not return the same element twice in a row, if there is > 1 elements in the queue)
	public T Cycle () {

		T elementToReturn = Dequeue(true);

		Enqueue(elementToReturn);

		return elementToReturn;

	}

	// Returns default value if there are no elements in the queue
	T randomElement () {

		if (_data.Count == 0) {

			return default(T);

		} else {

			return _data[Random.Range(0, _data.Count)];

		}

	}

	bool isMostRecent (T value) {
		return _mostRecentRemoved != null && value.Equals(_mostRecentRemoved);
	}

	// Tests the cycling functionality of the Queue
	bool canReturnNonMostRecentItem () { 
		return _data.Count > 1 || !isMostRecent(_data[0]);
	}
}
