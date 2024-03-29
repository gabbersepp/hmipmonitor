﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HmIpMonitor.EntityFramework.Models
{
    [Table("HmIpDevice")]
    public class HmIpDevice
    {
        [MaxLength(255)]
        [Key]
        public string Id { get; set; }

        public virtual List<DeviceParameter> DeviceParameter { get; set; }
    }
}