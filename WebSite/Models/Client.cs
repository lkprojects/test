using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class Client : DAL.Client
    {
        [Required(ErrorMessage = "יש למלא תעודת זהות", AllowEmptyStrings = false)]
        [DisplayName("תעודת זהות")]
        new public string TeudatZehut { get; set; }

        [Required(ErrorMessage = "יש למלא שם פרטי", AllowEmptyStrings = false)]
        [DisplayName("שם פרטי")]
        new public string FirstName { get; set; }
        
        [Required(ErrorMessage = "יש למלא שם משפחה", AllowEmptyStrings = false)]
        [DisplayName("שם משפחה")]
        new public string LastName { get; set; }

        [Required(ErrorMessage = "יש למלא כתובת הדואר האלקטרוני", AllowEmptyStrings = false)]
        [RegularExpression(@"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}",ErrorMessage="יש לספק כתובת דוא\"ל חוקית")]
        [DisplayName("כתובת דואר אלקטרוני")]
        new public string Email { get; set; }

        [Required(ErrorMessage = "יש למלא סיסמה", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(50,MinimumLength=8,ErrorMessage="סיסמה חייבת להיות בעלת לפחות 8 תוים")]
        [DisplayName("סיסמה")]
        new public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="הסיסמאות אינן תואמות")]
        [DisplayName("הזן שוב את הסיסמה")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "יש למלא מס' טלפון נייד", AllowEmptyStrings = false)]
        [DisplayName("מספר טלפון נייד")]
        new public string MobilePhoneNumber { get; set; }

        [DisplayName("רחוב")]
        new public string AddressStreetName { get; set; }
        [DisplayName("מספר")]
        new public string AddressStreetNumber { get; set; }

        [DisplayName("שם ישוב")]
        new public string AddressCity { get; set; }
        new public Nullable<byte> MaritalStatus { get; set; }

        [Required(ErrorMessage = "יש למלא תאריך לידה", AllowEmptyStrings = false)]
        [DisplayName("תאריך לידה")]        
        new public Nullable<System.DateTime> BirthDate { get; set; }

    }
}