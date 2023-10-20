﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Dealer.Model;

public partial class BankDetail
{
    [Key]
    public int BankId { get; set; }
    [Required]
    public string AccountNum { get; set; }
    [Required]
    public string HolderName { get; set; }
    [Required]
    public string IffcCode { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string FarmerEmail { get; set; }
}
