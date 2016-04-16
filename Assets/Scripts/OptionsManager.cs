using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Control Options Scene
public class OptionsManager : MonoBehaviour {

	public Toggle musicToggle;
	public Toggle sfxToggle;
	public Toggle ambToggle;

	void Start() {
		if (SettingsUtil.MusicMuted) {
			musicToggle.isOn = false;
		}
		if (SettingsUtil.FXMuted) {
			sfxToggle.isOn = false;
		}
		if (SettingsUtil.VOMuted) {
			ambToggle.isOn = false;
		}
	}
	// Mute/unmute music
	void ToggleMusic(){
		if (musicToggle.isOn) {
			SettingsUtil.ToggleMusicMuted (false);
		} else {
			SettingsUtil.ToggleMusicMuted (true);
		}
	}
	// Mute/unmute SFX
	void ToggleFX(){
		if (sfxToggle.isOn) {
			SettingsUtil.ToggleFXMuted (false);
		} else {
			SettingsUtil.ToggleFXMuted (true);
		}
	}
	// Mute/unmute Ambiance
	void ToggleAmbiance(){
		if (ambToggle.isOn) {
			SettingsUtil.ToggleVOMuted (false);
		} else {
			SettingsUtil.ToggleVOMuted (true);
		}
	}
}
