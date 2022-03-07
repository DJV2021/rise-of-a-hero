using UnityEngine;

namespace UI
{
    public class ResolutionButton : MonoBehaviour
    {
        void OnGUI()
        {
            string[] names = QualitySettings.names;
            GUILayout.BeginVertical();
            for (int i = 0; i < names.Length; i++)
            {
                if (GUILayout.Button(names[i]))
                {
                    QualitySettings.SetQualityLevel(i, true);
                }
            }

            GUILayout.EndVertical();
        }
    }
}
