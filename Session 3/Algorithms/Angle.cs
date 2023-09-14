
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {
    /// <summary>
    /// Clase Angle
    /// </summary>
    public class Angle {

        /// <summary>
        /// Propiedad Radians
        /// </summary>
        public double Radians { set; get; }

        /// <summary>
        /// Propiedad Degrees
        /// </summary>
        public double Degrees {
            get {
                return this.Radians / Math.PI * 180;
            }
            set {
                this.Radians = value / 180 * Math.PI;
            }
        }

        /// <summary>
        /// Constructor Angle
        /// </summary>
        /// <param name="radians"></param>
        public Angle(double radians) {
            this.Radians = radians;
        }

        /// <summary>
        /// Método CreateAngleDegrees
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        static public Angle CreateAngleDegrees(double degrees) {
            Angle angle = new Angle(0);
            angle.Degrees = degrees;
            return angle;
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
        /// Método Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Angle angle = obj as Angle;
            if (angle == null)
            {
                return false;
            }
            return this.Radians == angle.Radians;
        }

        /// <summary>
        /// Método GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Radians.GetHashCode();
        }

        /// <summary>
        /// Método ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"<Angle {this.Radians}>";
        }
    }
}