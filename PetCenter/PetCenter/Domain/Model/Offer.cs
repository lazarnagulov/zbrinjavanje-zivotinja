﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Enumerations;

namespace PetCenter.Domain.Model
{
    [Table("offer")]
    public class Offer
    {
        public Offer()
        {
        }

        public Offer(Person author, OfferType type)
        {
            Author = author;
            Type = type;
        }

        [Key]
        [Column("id_offer")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("person_author_o")]
        [Required]
        public Person Author { get; set; }

        [Required]
        [Column("type_o")]
        public OfferType Type { get; set; }

        [Required]
        [Column("status_o")]
        public Status Status { get; set; } = Status.OnHold;

        [ForeignKey("review_id_review")]
        public Review? Review { get; set; }
    }
}
