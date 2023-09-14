
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab01 
{

    /// <summary>
    /// Clase que calcula la potencia de 2 elevado a 32
    /// </summary>
    class Power {

        /// <summary>
        /// M�todo Main
        /// </summary>
        static void Main() {
            uint theBase = 2;
            uint exponent = 32;

            uint result = 1;

            if (theBase == 0) {
                Console.WriteLine("Power: 0.");
                return;
            }

            while (exponent > 0) {
                result *= theBase;
                exponent--;
            }

            Console.WriteLine("Power: {0}.", result);

            //Output:
            //0, debido al Overflow producido al superar el n�mero m�ximo de Integer.
            //Output con otro tipo:
            //4.294.967.296, el resultado real de la operaci�n,
            //ya que con un tipo que posea m�s bits, mayor rango de n�mero se podr�n representar
        }
    }

}

