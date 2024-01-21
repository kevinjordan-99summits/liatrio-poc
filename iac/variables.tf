variable "environment_name" {
  type        = string
  description = "The name of the environment (dev, qa, prod) this configuration applies to. This will be used when naming resources."
  nullable    = false
  default     = "poc"
}

variable "location" {
  type        = string
  description = "The Azure resources to create the resouces (southcentralus, westus2, etc.)"
  nullable    = false
  default     = "southcentralus"
}

variable "container_registry_url" {
  type        = string
  description = "The URL of the container registry to deploy images"
  nullable    = false
  default     = ""
}

variable "container_registry_username" {
  type        = string
  description = "The username for connecting to the container registry"
  nullable    = false
  default     = ""
}

variable "container_registry_password" {
  type        = string
  description = "The password for connecting to the container registry"
  nullable    = false
  default     = ""
}