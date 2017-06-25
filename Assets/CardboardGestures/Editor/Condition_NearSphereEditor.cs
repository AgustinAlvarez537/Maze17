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

			myScript.showZonaEsfera = EditorGUILayout.Toggle("Mostrar zonaEsfera (Rango)", myScript.showZonaEsfera);

            if (myScript.showZonaEsfera)
            {
                if (myScript.objeto2 != null && myScript.zonaEsfera == null)
                {
                    myScript.zonaEsfera = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    myScript.zonaEsfera.name = "Range sphere";
                    myScript.zonaEsfera.transform.position = myScript.objeto2.transform.position;
                    
                    myScript.zonaEsfera.transform.localScale = new Vector3(myScript.range * 2, myScript.range * 2, myScript.range * 2);
                    //myScript.zonaEsfera.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Transparent");
                    Color c = Color.yellow;
                    c.a = 0.3f;
                    myScript.zonaEsfera.GetComponent<Renderer>().material.color = c;
                    myScript.zonaEsfera.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                }
                if (myScript.range != myScript.oldRange)
                {
                    myScript.oldRange = myScript.range;
                    myScript.zonaEsfera.transform.position = myScript.objeto2.transform.position;
                    myScript.zonaEsfera.transform.localScale = new Vector3(myScript.range * 2, myScript.range * 2, myScript.range * 2);
                }
            }
            else
            {
                GameObject.DestroyImmediate(myScript.zonaEsfera);
                myScript.zonaEsfera = null;
            }
        }
    }
}