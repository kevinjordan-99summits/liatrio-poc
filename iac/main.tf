resource "azurerm_resource_group" "rg" {
  name     = "liatrio-rg-${var.environment_name}"
  location = var.location
  tags = {
    Environment = var.environment_name
  }
}

# Create app service plan for the website and functions
resource "azurerm_service_plan" "plan" {
  name                = "liatrio-plan-${var.environment_name}"
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  os_type             = "Linux"
  sku_name            = "B1"

  tags = {
    Environment = var.environment_name
  }
}


# API App
resource "azurerm_linux_web_app" "api_app" {
  name                          = "liatrio-api-${var.environment_name}"
  resource_group_name           = azurerm_resource_group.rg.name
  location                      = azurerm_resource_group.rg.location
  service_plan_id               = azurerm_service_plan.plan.id
  public_network_access_enabled = true

  site_config {
    application_stack {
      docker_image_name        = "liatriopocapi"
      docker_registry_url      = var.container_registry_url
      docker_registry_username = var.container_registry_username
      docker_registry_password = var.container_registry_password
    }
  }

  tags = {
    Environment = var.environment_name
  }
}


# Web App
resource "azurerm_linux_web_app" "web_app" {
  name                          = "liatrio-web-${var.environment_name}"
  resource_group_name           = azurerm_resource_group.rg.name
  location                      = azurerm_resource_group.rg.location
  service_plan_id               = azurerm_service_plan.plan.id
  public_network_access_enabled = true

  site_config {
    application_stack {
      docker_image_name        = "liatriopocweb"
      docker_registry_url      = var.container_registry_url
      docker_registry_username = var.container_registry_username
      docker_registry_password = var.container_registry_password
    }
  }

  app_settings = {
    ApiUrl = "https://${azurerm_linux_web_app.api_app.default_hostname}"
  }

  tags = {
    Environment = var.environment_name
  }
}
