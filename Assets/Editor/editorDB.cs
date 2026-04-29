using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(enemyClass), true)]
public class fovEditor : Editor
{
    private void OnSceneGUI()
    {
        enemyClass enemy = (enemyClass)target;

        Color x = Color.red;
        Handles.color = new Color(x.r, x.g, x.b, 0.1f);
        Handles.DrawSolidArc(
            enemy.transform.position,
            enemy.transform.forward,
            Quaternion.AngleAxis(-enemy.fovAngle / 2, enemy.transform.forward) * enemy.transform.up,
            enemy.fovAngle,
            enemy.fovRange);

        Handles.color = Color.white;
        enemy.fovRange = Handles.ScaleValueHandle(
            enemy.fovRange,
            enemy.transform.position + enemy.transform.up * enemy.fovRange,
            enemy.transform.rotation,
            2,
            Handles.SphereHandleCap,
            1);
    }
}
