<h1>GuideLines to implemenet HouseBroker Application </h1>

<ul>
  <li>The projcet has been prepared using <b>.NET 8</b>. Ensure its avaiability in your device.</li>
  <li>Clone the repository into your local device.</li>
  <li>Navigate to the <b>application.json</b> file in the HouseBroker.WebAPIs project and replace the existing Connection string with a connection string of a database that is accessible from your device.</li>
  <li>Ensure that the required dependecnies are correctly installed in the project you have created. Ensure that their is no version mismatch.</li>
  <li>The source code initializes the UserRoles and Users upon running the project. The data in the Property Table can be added by running the application with admin previliages of "House Broker" User Role. </li>
  <li>To implement the database migration from Package manager console, make sure that the target project is set to <b>HouseBroker.Infastructure</b> before executing the 'add-migration' and 'update-database' commands. </li>
  <li>To run the project in your local device's web browser, make sure that the the startup project is set to be <b>HouseBroker.WebAPIs</b>. This can be done by navigating to <b>Configure Stratup Projects...</b> .</li>
</ul>
