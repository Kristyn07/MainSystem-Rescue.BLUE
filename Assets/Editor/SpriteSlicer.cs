using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSlicer : EditorWindow
{

    static float threshold = 1;
    static Vector2 pivot = new Vector2(0.5f, 0.5f);

    void OnGUI()
    {
        threshold = Mathf.Clamp(EditorGUILayout.FloatField("Threshold: ", threshold), 0, 1);
        pivot = EditorGUILayout.Vector2Field("Pivot: ", pivot);

        if (GUILayout.Button("Slice"))
        {
            Slice();
        }

        this.Repaint();
    }

    [MenuItem("Sprite Slicer/Open Slicer")]
    static void OpenSlicer()
    {
        EditorWindow.GetWindow(typeof(SpriteSlicer));
    }

    static void Slice()
    {
        Object[] spriteSheets = Selection.GetFiltered<Texture2D>(SelectionMode.Assets);

        for (int z = 0; z < spriteSheets.Length; z++)
        {
            string path = AssetDatabase.GetAssetPath(spriteSheets[z]);
            TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
            ti.isReadable = true;
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

            if (ti.spriteImportMode != SpriteImportMode.Single)
                ti.spriteImportMode = SpriteImportMode.Single;

            ti.spriteImportMode = SpriteImportMode.Multiple;

            List<SpriteMetaData> newData = new List<SpriteMetaData>();

            Texture2D spriteSheet = spriteSheets[z] as Texture2D;

            int maxY = 0;
            int maxX = 0;

            int minY = spriteSheet.height;
            int minX = spriteSheet.width;

            for (int i = 0; i < spriteSheet.width; i++)
            {
                for (int j = spriteSheet.height; j >= 0; j--)
                {
                    if (spriteSheet.GetPixel(i, j).a >= threshold && j > maxY)
                        maxY = j;

                    if (spriteSheet.GetPixel(i, j).a >= threshold && j < minY)
                        minY = j;

                    if (spriteSheet.GetPixel(i, j).a >= threshold && i > maxX)
                        maxX = i;

                    if (spriteSheet.GetPixel(i, j).a >= threshold && i < minX)
                        minX = i;
                }
            }

            SpriteMetaData smd = new SpriteMetaData();
            smd.pivot = pivot;
            smd.alignment = 9;
            smd.name = spriteSheet.name;

            smd.rect = new Rect(minX, minY, (maxX - minX) + 1, (maxY - minY) + 1);

            newData.Add(smd);
            ti.spritesheet = newData.ToArray();
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
        }
    }
}
