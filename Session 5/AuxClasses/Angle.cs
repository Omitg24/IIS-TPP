
using System;

namespace TPP.Laboratory.Functional.Lab05 
{
    /// <summary>
    /// Clase Angle
    /// </summary>
    public class Angle {

        /// <summary>
        /// Propiedad Radians
        /// </summary>
        public double Radians { get; private set; }

        /// <summary>
        /// Propiedad Degrees
        /// </summary>
        public float Degrees {
            get { return (float)(this.Radians / Math.PI * 180); }
        }

        /// <summary>
        /// Constructor Angle con parámetro radians
        /// </summary>
        /// <param name="radians"></param>
        public Angle(double radians) {
            this.Radians = radians;
        }

        /// <summary>
        /// Constructor Angle con parámetro degrees
        /// </summary>
        /// <param name="radians"></param>
        public Angle(float degrees) {
            this.Radians = degrees / 180.0 * Math.PI;
        }

        /// <summary>
        /// Método Sine
        /// </summary>
        /// <returns></returns>
        public double Sine() {
            return Math.Sin(this.Radians);
        }

        /// <summary>
        /// Método Cosine
        /// </summary>
        /// <returns></returns>
        public double Cosine() {
            return Math.Cos(this.Radians);
        }

        /// <summary>
        /// Método Tangent
        /// </summary>
        /// <returns></returns>
        public double Tangent() {
            return Sine() / Cosine();
        }

        /// <summary>
        /// Propiedad Quadrant
        /// </summary>
        public int Quadrant {
            get {
                if (this.Radians <= Math.PI / 2)
                    return 1;
                if (this.Radians <= Math.PI)
                    return 2;
                if (this.Radians <= 3 * Math.PI / 2)
                    return 3;
                return 4;
            }
        }

    }

}