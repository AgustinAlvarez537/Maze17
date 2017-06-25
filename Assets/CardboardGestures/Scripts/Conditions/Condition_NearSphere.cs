using UnityEngine;
using System.Collections;
namespace CardboardGestures.Conditions
{
    public class Condition_NearSphere : AbstractCondition
    {
        public GameObject objeto1;
        public GameObject objeto2;
        public float range;
        public float oldRange;
        public GameObject globito;
        public bool showGlobito;

        // el range forma una esfera alrededor del centro del objeto que de ser traspasada hacia adentro hace que la función satisfied se evalue en true, de lo contrario en false

        void Start()
        {
			if (globito == null) 
			{
				globito = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			}
            globito.SetActive(false);
        }

        public override bool satisfied()
        {
            if (objeto1 != null && objeto2 != null)
            {
                Vector3 v = objeto1.transform.position - objeto2.transform.position;
                if (v.magnitude < range)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
