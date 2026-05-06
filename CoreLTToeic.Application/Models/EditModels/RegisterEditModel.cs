using CoreLTToeic.Application.Common.Constants;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLTToeic.Application.Models.EditModels
{
    public class RegisterEditModel
    {
        [EmailAddress]
        [Required(ErrorMessage = MessageConstants.EMAIL_INVALID)]
        public string Email { get; set; }

        [Required(ErrorMessage = MessageConstants.FIELD_REQUIRED)]
        public string UserName { get; set; }

        [Required(ErrorMessage = MessageConstants.FIELD_REQUIRED)]
        public string Password { get; set; }

        [Required(ErrorMessage = MessageConstants.FIELD_REQUIRED)]
        public string ConfirmPassword { get; set; }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
    }
}
