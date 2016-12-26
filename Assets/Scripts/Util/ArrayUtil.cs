/*
 * Author(s): Isaiah Mann 
 * Description: Static class with array helper functions
 */

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class ArrayUtil {

	// Removes empty strings from an Array of strings
	// Useful for text reading
	public static string [] RemoveEmptyElements (string [] original) {
		List<string> modified = new List<string>();

		for (int i = 0; i < original.Length; i++) {
			if (!string.IsNullOrEmpty(original[i]) && 
				original[i].Trim().Length != 0 &&
				original[i][0] != '\r' && 
				original[i][0] != '\n') {
				modified.Add(original[i]);
			}
		}

		return modified.ToArray();
	}

	public static T[] Fill<T> (T[] source, T value) {
		for (int i = 0; i < source.Length; i++) {
			source[i] = value;
		}
		return source;
	}

	// Returns an array w/ first element removed
	public static T[] RemoveFirst<T> (T[] source) {
		T[] modified = new T[source.Length - 1];

		Array.Copy(
			source,
			1,
			modified,
			0,
			modified.Length);

		return modified;
	}

	// Removes and returns first element of an array
	public static T Pop<T> (ref T[] arrayToModify) {
		T firstElement = arrayToModify[0];
		arrayToModify = RemoveFirst(arrayToModify);
		return firstElement;
	}

	// Creates an array of two arrays merged
	public static T[] Concat<T> (T[] source1, T[] source2) {
		T[] combined = new T[source1.Length + source2.Length];

		Array.Copy(source1, combined, source1.Length);
		Array.Copy(source2, 0, combined, source1.Length, source2.Length);

		return combined;
	}

	// Used to convert an array to string (for debugging purposes)
	public static string ToString<T> (T[] source) {
		string arrayAsString = "";

		for (int i = 0; i < source.Length; i++) {
			arrayAsString += source[i] + ",\n";
		}

		return arrayAsString;
	}

	// Fetches the first index of an array element
	public static int IndexOf<T> (T[] source, T element) where T : IComparable {
		for (int i = 0; i < source.Length; i++) {
			if (source[i].CompareTo(element) == 0) {
				return i;
			}
		}

		throw new KeyNotFoundException();
	}

	// Returns an array with the designated element removed
	public static T Remove<T> (ref T[]source, T element) where T : IComparable {
		int index = IndexOf(
			source,
			element);

		T[] modified = new T[source.Length-1];

		Array.ConstrainedCopy (
			source,
			0,
			modified,
			0,
			index-1);

		Array.ConstrainedCopy (
			source,
			index + 1,
			modified,
			index,
			source.Length - index - 1
		);

		return element;
	}

	// Adds an element to the list
	public static void Add<T> (ref T[]source, T element) {
		T[] modified = new T[source.Length+1];
		modified[source.Length] = element;
	}

	// Converts a list of arrays to a string for debugging
	public static string ToString<T> (List<T>[] source) {
		string result = string.Empty;

		for (int i = 0; i < source.Length; i++) {
			result +=  (i+1) + ". {\n" + ToString(source[i].ToArray()) + "}\n"; 
		}

		return result;
	}

	// Checks whether a an array contains an element
	public static bool Contains<T> (T[] source, T element) where T : IComparable {
		for (int i = 0; i < source.Length; i++) {
			if (source[i].CompareTo(element) == 0) {
				return true;
			}
		}

		return false;
	}

	public static int Sum (params int[] values) {
		int sum = 0;

		for (int i = 0; i < values.Length; i++) {
			sum += values[i];
		}

		return sum;
	}

}