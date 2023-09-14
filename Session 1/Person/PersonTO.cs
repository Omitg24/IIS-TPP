using System;

namespace TPP.Laboratory.ObjectOrientation.Lab01 
{

	/// <summary>
	/// Example class that only holds data: (Data) Transfer Object or Value Object
	/// </summary>
	class PersonTO {
		/// <summary>
		/// Propiedad FirstName
		/// </summary>
		public string FirstName { get; set; }
		/// <summary>
		/// Propiedad Surname
		/// </summary>
		public string Surname { get; set; }
		/// <summary>
		/// Propiedad Nationality
		/// </summary>
		public string Nationality { get; set; }
		/// <summary>
		/// Propiedad IDNumber
		/// </summary>
		public string IDNumber { get; set; }
		/// <summary>
		/// Propiedad DateOfBirth
		/// </summary>
		public DateTime DateOfBirth { get; set; }
		/// <summary>
		/// Propiedad Gender
		/// </summary>
		public Gender Gender { get; set; }
	
		/* Considering that many fields are optional (IDNumber, Nationality, DateOfBirth and Gender)
		* How many constructors should be defined?   
		*/
		//Deberían definirse 2 contstructores:
		//	PersonTO (FirstName, Surname)
		//	PersonTO (FirstName, Surname, IDNumberm Nationality, DateOfBirth, Gender)
	}
	
	/// <summary>
	/// Enumeración Gender
	/// </summary>
	enum Gender { Male, Female };
  
}

