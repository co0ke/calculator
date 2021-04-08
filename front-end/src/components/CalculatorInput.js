import React from "react";
import { TextField } from '@material-ui/core';

function CalculatorInput(props) {
    return (
        <TextField id={props.id}
                   InputProps={{ inputProps: { min: 0, max: 1, step: "any" } }} // Change max to '2' to test server side validation
                   label={props.label}
                   variant="outlined"
                   type="number"
                   required
                   value={props.value}
                   onChange={(e) => props.handleChange(e.target.value)} />
    );
}

export default CalculatorInput;