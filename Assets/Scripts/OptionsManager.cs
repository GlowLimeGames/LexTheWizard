using UnityEngine;
using System.Collections;

public class OptionsManager : MonoBehaviour {

	bool musicToggle = false;
	bool sfxToggle = false;
	bool ambianceToggle = false;

	void Update () {
		//SettingsUtil.ToggleMusicMuted (musicToggle);

	}


	public void ToggleMusic(){
		musicToggle = !musicToggle;
		SettingsUtil.ToggleMusicMuted (musicToggle);
	}

	public void ToggleFX(){
		sfxToggle = !sfxToggle;
		SettingsUtil.ToggleFXMuted (sfxToggle);
	}

	public void ToggleAmbiance(){
		ambianceToggle = !ambianceToggle;
		SettingsUtil.ToggleVOMuted (ambianceToggle);
	}
}
