using UnityEngine;
using System.Collections;
using UnityEditor;

namespace CardboardGestures.Conditions
{
    [CustomEditor(typeof(Condition_NearSphere))]
    public class Condition_NearSphereEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            Condition_NearSphere myScript = (Condition_NearSphere)target;
            myScript.objeto1 = (GameObject)EditorGUILayout.ObjectField("Objecto 1 (Movil)", myScript.objeto1, typeof(GameObject));

            myScript.objeto2 = (GameObject)EditorGUILayout.ObjectField("Objecto 2 (Inmovil)", myScript.objeto2, typeof(GameObject));

            myScript.range = EditorGUILayout.FloatField("Rango", myScript.range);

			myScript.showGlobito = EditorGUILayout.Toggle("Mostrar esfera (Rango)", myScript.showGlobito);

            if (myScript.showGlobito)
            {
                if (myScript.objeto2 != null && myScript.globito == null)
                {
                    myScript.globito = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    myScript.globito.name = "Range sphere";
                    myScript.globito.transform.position = myScript.objeto2.transform.position;
                    
                    myScript.globito.transform.localScale = new Vector3(myScript.range * 2, myScript.range * 2, myScript.range * 2);
                    //myScript.globito.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Transparent");
                    Color c = Color.yellow;
                    c.a = 0.3f;
                    myScript.globito.GetComponent<Renderer>().material.color = c;
                    myScript.globito.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                }
                if (myScript.range != myScript.oldRange)
                {
                    myScript.oldRange = myScript.range;
                    myScript.globito.transform.position = myScript.objeto2.transform.position;
                    myScript.globito.transform.localScale = new Vector3(myScript.range * 2, myScript.range * 2, myScript.range * 2);
                }
            }
            else
            {
                GameObject.DestroyImmediate(myScript.globito);
                myScript.globito = null;
            }
        }
    }
}