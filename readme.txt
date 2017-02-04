
SeeSomeCode.Console

	This is a simple console application that handles requests from the web application. Click "Build.Transform All T4 Templates" to generate assets from the SeeModel.xml model.
	Import the generated Generate.Postman.json file (paste the contents of that file) to test API controllers. Start this application before running the web application.

SeeSomeCode.Web

	MVC application with an Angular2 SPA... depends on the colsole application (above) so start that first. Notice that the AngularApp folder appears empty.. show all files to see the
	contents. I exclude them so that I can build without errors. You can edit and save as usual and the typescript transpiler will do its job.