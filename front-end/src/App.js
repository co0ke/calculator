import React from "react";
import Typography from '@material-ui/core/Typography';
import Calculator from './Calculator';
import { Container } from '@material-ui/core/';

function App() {
    return (
        <Container maxWidth="xs">
            <Typography variant="h3" component="h1" gutterBottom align="center">
                Calculator App
            </Typography>
            <Calculator/>
        </Container>
    );
}

export default App;
