const page = {
    async loadPage(baseApiUrl) {
        await this.fetchLayoutData();
        this.isLoading = false;
    }
};
