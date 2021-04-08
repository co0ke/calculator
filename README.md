# Front End Setup
- Navigate to 'front-end' folder
- Run 'npm install' command
- Run 'npm start' command
- This will start on http://localhost:3000, and this is the only URL defined in the CORS policy in the .NET Core API.
- To test the server side validation, modify src/components/CalculatorInput.js so that the 'max' value is greater than 1, then submit a value greater than 1 using the form.

# Back End Setup
- Start Calculator.Api using IIS Express. URL should be http://localhost:30956 and this is hardcoded in the React app.

# Back end future changes
- Opportunity to make calculation classes more DRY by sharing validation code.
- Validation messages could give more info, e.g. which parameter is incorrect. 
- Validation library such as FluentValidation could be used to extract validation out from calculation classes.
- API method parameters could be DTOs, these would then mapped to appropriate ICalculation instance rather than newing up inside controller.
- Allow configuration of CORS URLs.

# Front end future changes
- Better error handling.
- Use Material UI validation styles.
- Integrate into VS solution.
- Loading indicator on form submit.
- Allow configuration of API URL.