using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Sound))]
public class SoundEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Sound sound = (Sound)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Load All Clips"))
        {
            string folderPath = EditorUtility.OpenFolderPanel("Select Folder with Audio Clips", "Assets/Resources", "");
            if (!string.IsNullOrEmpty(folderPath))
            {
                int resourcesIndex = folderPath.IndexOf("Resources", System.StringComparison.Ordinal);
                if (resourcesIndex == -1)
                {
                    Debug.LogError("Audio clips must be in a 'Resources' folder for this to work.");
                    return;
                }

                string relativePath = folderPath.Substring(resourcesIndex + "Resources".Length + 1);
                LoadAllClips(sound, relativePath);
            }
        }
    }

    private void LoadAllClips(Sound sound, string folderPath)
    {
        Object[] loadedClips = Resources.LoadAll(folderPath, typeof(AudioClip));

        sound.soundTypes = new Sound.SoundType[loadedClips.Length];

        for (int i = 0; i < loadedClips.Length; i++)
        {
            AudioClip loadedClip = (AudioClip)loadedClips[i];

            sound.soundTypes[i] = new Sound.SoundType
            {
                typeName = loadedClip.name,
                clips = new AudioClip[] { loadedClip }
            };
        }
    }
}