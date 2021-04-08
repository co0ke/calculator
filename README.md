# Intro
Hello! I've tried to keep this app clean and simple. I've included some setup instructions below and also some potential future TODOs. I haven't used Material UI before but it was mentioned in the interview so thought I would give it a go...

Logs are written to /api/Calculator.Api/logs  

# Back End Setup
- Launch Calculator.Api. The URL should be http://localhost:30956 and this is hardcoded in the React app.

# Front End Setup
- Navigate to 'front-end' folder
- Run 'npm install' command
- Run 'npm start' command
- This will start on http://localhost:3000, and this is the only URL defined in the CORS policy in the .NET Core API.
- To test the server side validation, modify src/components/CalculatorInput.js so that the 'max' value is greater than 1, then submit a value greater than 1 using the form.

# Back end future TODO
- Opportunity to make calculation classes more DRY by sharing validation code.
- Validation messages could give more info, e.g. which parameter is incorrect. 
- Validation library such as FluentValidation could be used to extract validation out from calculation classes.
- API method parameters and responses could use DTOs defined in API project. A mapping tool would be used to map between types. In this way the data shape of Calculator.Src project would not be exposed. Also it would mean the request DTO could be mapped to the appropriate ICalculation instance rather than being newed up inside controller.
- Allow configuration of CORS URLs.
- Integation tests.

# Front end future TODO
- Better error handling.
- Use Material UI validation styles.
- Integrate into VS solution.
- Loading indicator on form submit.
- Allow configuration of API URL.
