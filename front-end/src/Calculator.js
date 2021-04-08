import React, { useState } from "react";
import { ApiClient } from "./ApiClient";
import { Button, TextField, Select, FormControl, MenuItem, makeStyles } from '@material-ui/core';
import Alert from '@material-ui/lab/Alert';

const useStyles = makeStyles((theme) => ({
    root: {
        '& .MuiTextField-root, & .MuiButtonBase-root': {
            margin: theme.spacing(1),
            width: "100%",
        },
    },
    formControl: {
        margin: theme.spacing(1),
    },
    error: {
        width: "96%",
        padding: "2%",
        margin: theme.spacing(1),
    }
}));

function Calculator() {
    const classes = useStyles();

    const [pa, setPa] = useState("");
    const [pb, setPb] = useState("");
    const [mode, setMode] = useState("combinedwith");
    const [result, setResult] = useState("");
    const [serverErrors, setServerErrors] = useState([]);

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(`Submitting pa: ${pa}, pb: ${pb}, mode: ${mode}`);

        ApiClient.calculate(pa, pb, mode).then(json => {
            if (json?.validation?.isValid === true) {
                setResult(json.value);
                setServerErrors([]);
            }

            if(json?.validation?.isValid === false) {
                setResult("");
                setServerErrors(json.validation.errors);
            }
        });
    }

    return (
        <form className={classes.root} onSubmit={handleSubmit}>
            <TextField id="pa"
                       InputProps={{ inputProps: { min: 0, max: 2, step: "any" } }} // Change max to '2' to test server side validation
                       label="Parameter A"
                       variant="outlined"
                       type="number"
                       required
                       value={pa}
                       onChange={(e) => setPa(e.target.value)} />

            <TextField id="pb"
                       InputProps={{ inputProps: { min: 0, max: 1, step: "any" } }}
                       label="Parameter B"
                       variant="outlined"
                       type="number"
                       required
                       value={pb}
                       onChange={(e) => setPb(e.target.value)} />

            <FormControl variant="outlined" className={classes.formControl} fullWidth={true}>
                <Select id="mode" value={mode} onChange={(e) => setMode(e.target.value)}>
                    <MenuItem value="combinedwith">Combined With</MenuItem>
                    <MenuItem value="either">Either</MenuItem>
                </Select>
            </FormControl>

            <Button variant="contained" color="primary" type="submit" fullWidth={true}>
                Calculate
            </Button>

            <TextField disabled id="result" variant="filled" label="Result" value={result} />

            {serverErrors.length > 0 &&
                serverErrors.map((error, index) => <Alert severity="error" key={index} className={classes.error}>{error.errorMessage}</Alert>)
            }
        </form>
    );
}

export default Calculator;

// TODO: ESLint Plugin