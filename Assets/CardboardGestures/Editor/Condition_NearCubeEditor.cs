using UnityEngine;
using System.Collections;
using UnityEditor;

namespace CardboardGestures.Conditions
{
    [CustomEditor(typeof(Condition_NearCube))]
    public class Condition_NearCubeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            Condition_NearCube myScript = (Condition_NearCube)target;

            myScript.objeto1 = (GameObject)EditorGUILayout.ObjectField("Objecto 1 (Movil)", myScript.objeto1, typeof(GameObject));

            myScript.showCubito = EditorGUILayout.Toggle("Mostrar cubo", myScript.showCubito);
            myScript.posicion = EditorGUILayout.Vector3Field("Posición del cubo", myScript.posicion);
            myScript.lado = EditorGUILayout.FloatField("Longitud de cada lado", myScript.lado);

            if (myScript.showCubito)
            {
                if (myScript.cubito == null)
                {
                    myScript.cubito = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //myScript.cubito.GetComponent<MeshRenderer>().materials = new Material[0];
                    myScript.cubito.name = "Range cube";
                    myScript.cubito.transform.position = myScript.posicion;
                    Color c = Color.yellow;
                    c.a = 0.3f;
                    myScript.cubito.GetComponent<Renderer>().material.color = c;


                    myScript.cubito.transform.localScale = new Vector3(myScript.lado / 2, myScript.lado / 2, myScript.lado / 2);
                }

                if (myScript.lado != myScript.oldLado)
                {
                    myScript.oldLado = myScript.lado;
                    myScript.cubito.transform.position = myScript.posicion;
                    myScript.cubito.transform.localScale = new Vector3(myScript.lado / 2, myScript.lado / 2, myScript.lado / 2);
                }
            }
            else
            {
                GameObject.DestroyImmediate(myScript.cubito);
                myScript.cubito = null;
            }
        }
    }
}