namespace MVCProj1.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Audio
    {
        [Required(ErrorMessage = "A title is required.")]
        public string SongName { get; set; }

        [Required(ErrorMessage = "A link is required.")]
        [IsWorkingUrl(ErrorMessage = "Link must be valid.")]
        public string SongLink { get; set; }
    }
    public class IsWorkingUrl : ValidationAttribute
    {
        public string GetErrorMessage() =>
            "Link must be valid.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string v = Convert.ToString(value);
            return (Uri.IsWellFormedUriString(v, UriKind.Absolute)
                || Uri.IsWellFormedUriString("https://" + v, UriKind.Absolute))
                && !new List<int> { -1, v.Length - 1, v.Length - 2 }.Contains(v.IndexOf('.')) ?
                ValidationResult.Success : new ValidationResult(GetErrorMessage());

        }
    }
}
