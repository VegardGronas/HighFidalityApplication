using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(GameManager))]
public class CustomEditors : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement inspector = new VisualElement();

        VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/HighFidalityApplication/HighFidalityModel/Editor/XML/GameManagerInspector.uxml");
        visualTree.CloneTree(inspector);

        return inspector;
    }
}
