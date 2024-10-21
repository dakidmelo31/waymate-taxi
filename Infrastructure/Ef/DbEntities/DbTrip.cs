﻿namespace Infrastructure.Ef.DbEntities;

public class DbTrip
{
    public int Id { get; set; }
    public int IdDriver { get; set; }
    public bool Smoke { get; set; }
    public double Price { get; set; }
    public bool Luggage { get; set; }
    public bool PetFriendly { get; set; }
    public DateTime Date { get; set; }
    public string DriverMessage { get; set; }
    public bool AirConditioning { get; set; }
    public int IdStartingPoint { get; set; }
    public int IdDestination { get; set; }

}