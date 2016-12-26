/*
 * Author: Isaiah Mann
 * Description: Wrapper class to extend the default behaviour of MonoBehaviours
 */

using UnityEngine;
using System.Collections;

public abstract class MonoBehaviourExtended : MonoBehaviour, System.IComparable {
	IEnumerator moveCoroutine;
	public delegate void MonoAction();
	public delegate void MonoActionf(float value);

	void Awake () {
		SetReferences();
		SubscribeEvents();
	}

	void Start () {
		FetchReferences();
	}

	void OnDestroy () {
		CleanupReferences();
		UnusbscribeEvents();
		StopAllCoroutines();
	}

	// Value should only be null if you're setting a trigger
	public bool QueryAnimator (AnimParam param, string key, object value = null) {
		Animator animator = GetComponent<Animator>();
		if (animator == null) {
			return false;
		} else {
			try {
				switch (param) {
				case AnimParam.Bool:
					animator.SetBool(key, (bool)value);
					return true;
				case AnimParam.Float:
					animator.SetFloat(key, (float)value);
					return true;
				case AnimParam.Int:
					animator.SetInteger(key, (int)value);
					return true;
				case AnimParam.Trigger:
					animator.SetTrigger(key);
					return true;
				default:
					return false;
				}
			} catch {
				return false;
			}
		}
	}

	public bool QuerySpriteRenderer (Sprite sprite) {
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		if (renderer == null) {
			return false;
		} else {
			renderer.sprite = sprite;
			return true;
		}
	}

	protected virtual void SubscribeEvents () {
		EventController.OnNamedEvent += HandleNamedEvent;
	}

	protected virtual void UnusbscribeEvents () {
		EventController.OnNamedEvent -= HandleNamedEvent;
	}

	protected abstract void SetReferences ();

	protected abstract void FetchReferences ();

	protected abstract void CleanupReferences ();

	protected abstract void HandleNamedEvent (string eventName);

	public int CompareTo (object other) {
		if (other is MonoBehaviourExtended) {
			return this == (other as MonoBehaviourExtended) ? 0 : -1;
		} else {
			return -1;
		}
	}

	protected void moveTo (Vector3 targetPosition, float time, MonoAction callBack = null) {
		haltMoveTo();
		moveCoroutine = linearLerp(transform, targetPosition, time, callBack);
		StartCoroutine(moveCoroutine);
	}

	protected void haltMoveTo () {
		if (moveCoroutine != null) {
			StopCoroutine(moveCoroutine);
		}
	}

	protected IEnumerator linearLerp (Transform transform, Vector3 targetPosition, float totalTime, MonoAction callBack = null) {
		float timer = 0;
		Vector3 startPosition = transform.position;
		while (timer <= totalTime) {
			transform.position = Vector3.Lerp(startPosition, targetPosition, timer);
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		transform.position = targetPosition;
		if (callBack != null) {
			callBack();
		}
	}

	protected void scale (Transform transform, float scaleFactor) {
		transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
	}

	protected void scale (float scaleFactor) {
		scale(transform, scaleFactor);
	}
}
