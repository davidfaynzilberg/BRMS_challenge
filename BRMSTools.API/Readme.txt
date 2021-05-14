AppGuard Coding Challenge - Borrower Risk Management System

Second Bank of Chantilly invests a lot of money in real estate lending. Making sure its borrowers are and
continue to be financially stable and people with high integrity is key to their success. To support this,
they would like to build a “Borrower Risk Management System” (BRMS) to monitor their clients’ statuses.
This system will track borrowers’ financial records and criminal ratings, and would immediately notify
management of any issues. BRMS will interface with the National Crime Database (NCDB) and Credit
Bureau services for this data. (Note: These are both fictitious and are services to be created as part of
the exercise.)

The system requirements are:
1. BRMS should manage borrower personal information. The borrower records should include
name, date of birth, 9-digit social security number (SSN), and mailing address.
2. BRMS should interface with the National Crime Database (NCDB) system to monitor borrowers’
criminal records. The NCDB can simply track a “crime index” to SSNs.
3. BRMS should interface with the Credit Bureau system to monitor financial activities (credit
scores). This can simply track a credit score to SSNs.
4. The BRMS should provide a public API interface to receive alerts from NCDB and Credit Bureau.
5. The NCDB and Credit Bureau services provide REST APIs to register for notifications on SSNs.
6. The BRMS should have a UI to input borrower information.
7. Once the BRMS detects an alert condition, immediately notify company management on the UI.

Project requirement are:
1. Design an architecture for the system and present this in a simple design document including
component diagrams.
2. Develop in C# / .NET Core and provide source code in a buildable solution (Microsoft Visual
Studio or Code).
3. Provide implementations for all of the BRMS components.
4. Provide simple implementations of the NCDB and Credit Bureau to feed alerts to the BRMS.
5. Provide a web interface to add borrowers into the BRMS, as well as to view alerts on borrowers.
Use the UI technology of your choice.
6. Write an event generator that will create/update records in the NCDB and Credit Bureau systems
to simulate activity. This should include triggers of alerts.
7. Write unit tests for one or more components. (You may focus on a single component to
demonstrate a more complete set.)
8. All of the above implementations should showcase your API and system design skills.
In order to keep this exercise manageable, focus on building out the structure of the system and the APIs;
the actual functionality can be simple.

