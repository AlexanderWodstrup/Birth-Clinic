|| README ||

I4DAB, Assignment 2

To run the program:

	1. Open solution in Visual Studio

	2. In Visual Studio, go to Tools -> NuGet Package Manager -> Packet Manager Console.

	3. Write "Add-Migration InitialSchema" and Press "Enter".
	
	4. Write "Update-Database" and Press "Enter".

	5. Close the Package Manager Console and Press "F5" to run the Program.

	6. Write the "Clear" command in the console.

	7. Write the "Seed" command in the console.

	8. Use the commands in the console i.e. "Check" to check the planned births for the next three days.





Commands available:

	Check: Check the planned births for the next three days.

	CW: Check clinicians scheduled for work and rooms available for the next five days.

	Ongoing: Check ongoing births.

	List: Get a list of the rooms in the Birth Clinic.

	Clear: Clear Database

	Seed: Seed Database with dummy data.

	Exit: Close program.


Udfordringer med opgaven:
	
	Grundet udfordringer med opgaven samt tidspres, har det ikke været muligt at implementere samtlige views. Det er tilstræbt at muliggøre de tre første views,
	mens de to sidste ikke har været mulige at implementere. Derudover har vi statisk defineret parents, så disse er altså ikke dynamisk tilføjet - igen for at 
	muliggøre en eksekvering af programmet i forhold til at opnå så mange views som muligt.





