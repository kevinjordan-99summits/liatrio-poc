namespace LiatrioPoC.Api.Models.NameValues
{
    public class NameValueGetModel
    {
        /// <summary>
        /// ID of the setting
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the setting
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Value stored in the setting
        /// </summary>
        public string? Value{ get; set; }
    }
}
