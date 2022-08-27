// ######################################################################
// DialogueManagerTesterEditor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;
using UnityEditor;

namespace Project.DialogueSystem
{
    [CustomEditor(typeof(DialogSystemTester))]
    public class DialogSystemTesterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            DialogSystemTester dialogSystemTester = (DialogSystemTester)target;
            if (GUILayout.Button("Run Dialogue Test"))
            {
                dialogSystemTester.DoTest();
            }
        }
    }
}
