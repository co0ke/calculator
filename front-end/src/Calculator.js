import React, {useState} from "react";
import { ApiClient } from "./ApiClient";

function Calculator() {
    const [pa, setPa] = useState("");
    const [pb, setPb] = useState("");
    const [mode, setMode] = useState("combinedwith");
    const [result, setResult] = useState(null);
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
                setServerErrors(json.validation.errors);
            }
        });
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <label>
                    Parameter A:&nbsp;
                    <input type="number"
                           step="any"
                           min="0"
                           max="2" //TODO: change back to 1
                           value={pa}
                           onChange={(e) => setPa(e.target.value)}/>
                </label>
                <label>
                    Parameter B:&nbsp;
                    <input type="number"
                           step="any"
                           min="0"
                           max="1"
                           value={pb}
                           onChange={(e) => setPb(e.target.value)}/>
                </label>
                <label>
                    Mode:&nbsp;
                    <select value={mode} onChange={(e) => setMode(e.target.value)}>
                        <option value="combinedwith">Combined With</option>
                        <option value="either">Either</option>
                    </select>
                </label>
                <div>
                    <input type="submit" value="Calculate"/>
                </div>
                <p>Result: {result}</p>

                {serverErrors.length > 0 &&
                    <div>
                        <ul>
                            {serverErrors.map((error, index) =>
                                <li key={index}>{error.errorMessage}</li>)}
                        </ul>
                    </div>
                }
            </form>
        </div>
    );
}

export default Calculator;

// TODO: ESLint Plugin