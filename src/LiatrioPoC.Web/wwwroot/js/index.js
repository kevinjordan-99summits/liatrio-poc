const page = {
    categories: [],
    async loadPage(baseApiUrl) {
        await this.fetchLayoutData();

        let results = getApiCall(`${baseApiUrl}/categories`);
        this.categories = results;

        this.isLoading = false;
    }
};