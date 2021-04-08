export const ApiClient = {
    calculate: (pa, pb, mode) => {
        const url = `http://localhost:30956/calculate/${mode}/?pa=${pa}&pb=${pb}`;

        return fetch(url)
            .then(function (response) {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response;
            })
            .then((response) => response.json())
            .then((json) => json)
            .catch(error => {
                console.log(error)
                return {
                    validation: {
                        isValid: false,
                        errors: [{
                            errorMessage: error.message
                        }]
                    }
                }
            });
    }
};