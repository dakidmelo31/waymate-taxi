﻿namespace Application.UseCases.Users.User.Dto;

public class DtoOutputUser
{
    
     public int Id { get; set; }
     public string Username { get; set; }
     public string UserType { get; set; }
     public string Password { get; set; }
     public string Email { get; set; }
     public DateTime Birthdate { get; set; }
     public bool IsBanned { get; set; }
     public string PhoneNumber { get; set; }
     public string? LastName { get; set; }
     public string? FirstName { get; set; }
     public string? Gender { get; set; }
     public int AddressId { get; set; }
     public string CarPlate { get; set; }
}