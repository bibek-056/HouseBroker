﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Core.DTOs.PropertyDTOs
{
    public class PropertyReadDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PropertyId { get; set; }
        [MaxLength(30)]
        public required string PropertyName { get; set; }
        [MaxLength(30)]
        public required string State { get; set; }
        [MaxLength(30)]
        public required string District { get; set; }
        [MaxLength(30)]
        public required string Municipality { get; set; }
        [Range(0, 32)]
        public required int WardNo { get; set; }
        [MaxLength(30)]
        public string? Location { get; set; }
        public string? PhotoURL { get; set; }
        [MaxLength(300)]
        public string? PropertyDescription { get; set; }
        [MaxLength(30)]
        public required string PropertyType { get; set; }
        public required string AskingPrice { get; set; }
        public required DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public long? BrokerContact { get; set; }
    }
}
