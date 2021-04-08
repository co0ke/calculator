import React from 'react';
import Typography from '@material-ui/core/Typography';
import { Container } from '@material-ui/core/';
import Calculator from './components/Calculator';

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
