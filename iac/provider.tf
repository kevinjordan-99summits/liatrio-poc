terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.86.0"
    }
  }

  # Store Terraform state in an Azure Storage Account
  # You can't use variables here, so when calling terraform init, use
  #    -backend-config="access_key=..."
  backend "azurerm" {
    resource_group_name  = "liatrio-core-rg"
    storage_account_name = "liatriocorekjpoc"
    container_name       = "terraform"
    key                  = "tfstate-dev"
  }
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}