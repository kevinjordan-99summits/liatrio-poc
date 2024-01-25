const page = {
    katas: [],
    async loadPage(baseApiUrl) {
        await this.fetchLayoutData();

        let categoryId = window.location.pathname.split('/')[2];
        let results = getApiCall(`${baseApiUrl}/categories/${categoryId}/katas`);
        this.katas = results;

        this.isLoading = false;
    }
};