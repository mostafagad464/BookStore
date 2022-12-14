using Acme.BookStore.Authors;
using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Authors
{
    public class UpdateAuthorDto
    {
        [Required]
        [MaxLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        
        public string ShortBio { get; set; }
    }
}