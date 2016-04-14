using UnityEngine;
using System.Collections;

public class OptionsManager : MonoBehaviour {

	bool muteMusic = false;
	bool muteSfx = false;
	bool muteAmbiance = false;

	void ToggleMusic(){
		muteMusic = !muteMusic;
		SettingsUtil.ToggleMusicMuted (muteMusic);
	}

	void ToggleFX(){
		muteSfx = !muteSfx;
		SettingsUtil.ToggleFXMuted (muteSfx);
	}

	void ToggleAmbiance(){
		muteAmbiance = !muteAmbiance;
		SettingsUtil.ToggleVOMuted (muteAmbiance);
	}
}
