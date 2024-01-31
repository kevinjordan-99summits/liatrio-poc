# Liatrio DevOps Proof of Concept
DevOps Katas provides practitioners a way to hone their craft through different learning exercises.

The site also serves as a proof of concept for modern application architecture. It includes a front-end built with [Tailwind CSS](https://tailwindcss.com/) and [Alpine.js](https://alpinejs.dev/). It talks to a REST-based backend written in C#. The site is deployed on Docker containers in Azure.

## Links
- [Demo Web](https://liatrio-web-prod.azurewebsites.net/)
- [Demo API](https://liatrio-api-prod.azurewebsites.net/swagger/index.html)

## Developer Setup
In order to run this application locally, you must have Visual Studio installed with [.NET Core 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0). Open the LiatrioPoC.sln and run with multiple startup projects enabled (LiatrioPoC.Api & LiatrioPoC.Web).

To test using Docker, you must have [Docker desktop](https://www.docker.com/products/docker-desktop/) installed.

## Infrastructure Setup
For simplicity, the Core Resource Group was manually configured. It contains resources that will be used by all environments.

Each environment resource group is deployed dynamically from a reusable Terraform module via GitHub Actions.

To create a new environment, an environment first needs to be adding in GitHub. Two environment variables must be set:
| Name              | Description                                        |
| ----------------- | -------------------------------------------------- |
| ENV_NAME          | The name of the environment (e.g. dev, qa, prod)   |
| AZURE_WEBAPP_NAME | The hostname for the website (e.g. liatrio-web-qa) |

Add the new environment into the [terraform-ci.yml](https://github.com/kevinjordan-99summits/liatrio-poc/blob/51f6d9f7547b55cb6f47d66607e0b8b2056e71c8/.github/workflows/terraform-ci.yml). From there you can run the workflow which will setup the Azure resource group, app service plan, and application services for the website and API.

## Deployment Setup
To deploy the website and API, you'll need to add the [app service publishing profiles](https://learn.microsoft.com/en-us/visualstudio/azure/how-to-get-publish-profile-from-azure-app-service?view=vs-2022) from Azure into environment secrets:
| Name                         | Description                              |
| ---------------------------- | ---------------------------------------- |
| AZURE_APIAPP_PUBLISH_PROFILE | The publishing profile from the API app. |
| AZURE_WEBAPP_PUBLISH_PROFILE | The publishing profile from the web app. |

Add the new environment into the [deploy-api.yml](https://github.com/kevinjordan-99summits/liatrio-poc/blob/51f6d9f7547b55cb6f47d66607e0b8b2056e71c8/.github/workflows/deploy-api.yml) and [deploy-web.yml](https://github.com/kevinjordan-99summits/liatrio-poc/blob/51f6d9f7547b55cb6f47d66607e0b8b2056e71c8/.github/workflows/deploy-web.yml). From there you can run the workflows to deploy the latest container image to the new environments.

## Teardown 
Since the environments are built using Terraform, you could create an additional pipeline for ```terraform destroy```, however for simplicy, it's easiest just to delete the resource groups from Azure.
