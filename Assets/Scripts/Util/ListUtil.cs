/*
 * Author: Isaiah Mann
 * Description: Utility methods to assist with using List class
 * All methods are static
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ListUtil {

	// Checks list for elements
	public static bool IsNullOrEmpty<T> (List<T> list) {
		return list == null || list.Count == 0;
	}

	public static string ToString<T> (List<T> list) {
		if (list == null) {

			return null;

		} else {

			string listAsString = "";

			for (int i = 0; i < list.Count; i++) {
				listAsString += list[i].ToString() + '\n';
			}

			return listAsString;

		}
	}

	// Checks whether an index is in range
	public static bool InRange<T> (List<T> list, int index) {
		if (IsNullOrEmpty(list)) {
			return false;
		} else {
			return index >= 0 && index < list.Count;
		}
	}
}
