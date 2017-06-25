using UnityEngine;

namespace CardboardGestures.Gestures
{
    public class Gesture_TiltRight : AbstractGesture
    {

		public float inclinacion = 0.7f;
        public DeviceOrientation orientation;
        private Vector3 initialVector;

        public override string GestureName()
        {
            return "Tilt Right";
        }

        void Start()
        {

            initialVector = new Vector3(0.0f, -1.0f, 0.0f);
        }

        public override bool Analyze()
        {
            if ((orientation == DeviceOrientation.LandscapeLeft
				&& initialVector.x + inclinacion < Input.acceleration.x)
               ||
               (orientation == DeviceOrientation.LandscapeRight
					&& initialVector.x - inclinacion < Input.acceleration.x)
               )
            {
                return true;
            }
            return false;
        }
    }
}