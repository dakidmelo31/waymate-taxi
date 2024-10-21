﻿using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Users.Passenger.Dto; 

public class DtoInputUpdatePassenger {
    
    [Required] public int Id { get; set; }
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string Email { get; set; }
    [Required] public DateTime Birthdate { get; set; }
    [Required] public bool IsBanned { get; set; }
    [Required] public string PhoneNumber { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string Gender { get; set; }
    [Required] public int AddressId { get; set; }
}