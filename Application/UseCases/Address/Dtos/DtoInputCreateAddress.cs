﻿using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Address.Dtos;

public class DtoInputCreateAddress
{
    [Required] public string Street { get; set; }
    [Required] public string PostalCode { get; set; }
    [Required] public string City { get; set; }
    [Required] public string Number { get; set; }
    [Required] public string Country { get; set; }
}