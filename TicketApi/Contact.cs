using System.ComponentModel.DataAnnotations;

namespace TicketApi
{
    public class Contact
    {
        [Required]
        public int concertId { get; set; }


        [EmailAddress(ErrorMessage = "Please enter a valid email address (name@example.com)")]
        [Required(ErrorMessage = "An email address is required to proceed.")]
        public String Email { get; set; } = string.Empty;
        

        [Required(ErrorMessage = "Name is required.")]
        public String Name { get; set; } = string.Empty;


        //[Required(ErrorMessage = "Last name is required.")]
        //public String LastName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter a phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number (xxx-xxx-xxxx)")]
        public String Phone {  get; set; } = String.Empty;


        [Required]
        [Range(1,24)] // Cutting the scalpers off
        public int Quantity { get; set; } = 0;


        [CreditCard(ErrorMessage = "Please provide a valid credit card number.")]
        [Required(ErrorMessage = "Credit card is required.")]
        public String CreditCard { get; set; } = String.Empty;
        //4417 1234 5678 9113


        [Required(ErrorMessage = "Expiration date is required.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Expiration must be in MM/YY format.")]
        public String Expiration {  get; set; } = String.Empty;


        [Required(ErrorMessage = "Security Code is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Security Code must be 3 or 4 digits.")]
        public String SecurityCode {  get; set; } = String.Empty;

        [Required]
        public String Address { get; set; } = String.Empty;

        [Required]
        public String City { get; set; } = String.Empty;

        [Required]
        public String Province { get; set; } = String.Empty;

        [Required(ErrorMessage = "Postal Code is required.")] //I got this regex from the internet, found a great resource at https://regex101.com/
        [RegularExpression(@"(^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$)|(^\d{5}(-\d{4})?$)", ErrorMessage = "Postal Code must be a valid Canadian or US postal code.")]
        public String PostalCode { get; set; } = String.Empty;

        [Required]
        public String Country { get; set; } = String.Empty;

    }
}
