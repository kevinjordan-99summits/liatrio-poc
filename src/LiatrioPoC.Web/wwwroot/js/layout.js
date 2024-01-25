const layout = {
    isLoading: true,
    async fetchLayoutData() {
    },
    ...page
};

window.layout = layout;

async function getApiCall(apiUrl) {
    return fetch(apiUrl)
        .then(async function (response) {
            if (response.ok)
                return response.json();

            return null;

        });
}