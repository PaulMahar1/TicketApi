using System.ComponentModel.DataAnnotations;

namespace TicketApi
{
    public class Contact
    {
        public int concertId { get; set; }

        [EmailAddress]
        [Required]
        public String Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "First name is required.")]
        public String FirstName { get; set; } = string.Empty;

        [Required]
        public String LastName { get; set; } = string.Empty;
        
        [Phone]
        public String Phone {  get; set; } = String.Empty;

        public int Quantity { get; set; } = 0;

        [CreditCard]
        [Required]
        public String CreditCard { get; set; } = String.Empty;

        
        public String Expiration {  get; set; } = String.Empty;

        
        public String SecurityCode {  get; set; } = String.Empty;
        
        public String Address { get; set; } = String.Empty;

        public String City { get; set; } = String.Empty;

        public String Province { get; set; } = String.Empty;
        
        public String PostalCode { get; set; } = String.Empty;

        public String Country { get; set; } = String.Empty;

    }
}
