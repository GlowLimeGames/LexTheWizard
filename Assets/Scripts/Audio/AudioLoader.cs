/*
 * Author: Isaiah Mann
 * Description: Class to load in the audio from a JSON file
 * Dependencies: None
 */
using SimpleJSON;
using UnityEngine;
using System.Collections;

public class AudioLoader {
	const string DIRECTORY = "Audio/";

	const bool OLD_VERSION_UNITY = true;
	// The path within the directory where the JSON file is saved
	string _path;

	public AudioLoader (string path) {
		this._path = path;
	}

	// Returns a C# class formatted like corresponding JSON file
	// JSON file must be formatted to match class structure or will throw an error
	public AudioList Load () {

#if UNITY_5_3
		AudioList audioList = JsonUtility.FromJson<AudioList>(
			FileUtil.FileText (
				this._path
			)
		);

		audioList.SubscribeEvents();

		return audioList;
#else

		JSONNode parentNode = JSON.Parse(
			TextAssetUtil.FileText (
				_path
			)
		);


		return new AudioList (
			ParseAudioFiles (
				parentNode
			)
		);
#endif

	}

	AudioFile[] ParseAudioFiles (JSONNode parentNode) {
		JSONArray audioFileArrayAsJSON = parentNode["Audio"].AsArray;
		
		AudioFile[] audioFiles = new AudioFile[audioFileArrayAsJSON.Count];
		
		for (int i = 0; i < audioFileArrayAsJSON.Count; i++) {
			audioFiles[i] = ParseAudioFile(audioFileArrayAsJSON[i]);
		}
		
		return audioFiles;
	}

	AudioFile ParseAudioFile (JSONNode audioFile) {
		AudioFile audio = new AudioFile();

		audio.FileName = audioFile["FileName"];
		
		audio.EventNames = JSONUtil.GetStringArray(audioFile["EventNames"].AsArray);

		
		audio.StopEventNames = JSONUtil.GetStringArray(audioFile["StopEventNames"].AsArray);
		
		audio.Loop = audioFile["Loop"].AsBool;
		
		audio.Type = audioFile["Type"];
		
		audio.Channel = audioFile["Channel"].AsInt;

		audio.Volume = audioFile["Volume"].AsInt;

		return audio;
	}


	// Fetches a particular clip from the resources folder
	public static AudioClip GetClip (string fileName) {
		return Resources.Load<AudioClip>(
			DIRECTORY + fileName
		);
	}

	public static AudioClip GetClip (AudioFile file) {
		return GetClip(file.FileName);
	}

}