﻿using System.Diagnostics.CodeAnalysis;
using Domain.Enums;
using Infrastructure.Ef.Address;
using Infrastructure.Ef.Authentication;
using Infrastructure.Ef.DbEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Ef.Users.User;

public class UserRepository : IUserRepository {
    private readonly WaymateContext _context;
    private readonly IPasswordHasher _passwordHasher;

    public UserRepository(WaymateContext context, IPasswordHasher passwordHasher) {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public IEnumerable<DbUser> FetchAll() {
        return _context.Users.ToList();
    }

    public DbUser FetchById(int id) {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) throw new KeyNotFoundException($"User with id {id} has not been found");
        return user;
    }

    public DbUser FetchByEmail(string email) {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null) throw new KeyNotFoundException($"User with email {email} has not been found");
        return user;
    }
    public bool FetchByEmailBool(string email) {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (user == null) return false;

        return true;
    }

    public DbUser FetchByUsernameDbUser(string username) {
        var user = _context.Users.FirstOrDefault(a => a.Username == username);
        if (user == null) throw new KeyNotFoundException($"User with username {username} has not been found.");
        return user;
    }

    public bool FetchByUsername(string username)
    {
        var user = _context.Users.FirstOrDefault(a => a.Username == username);

        if (user == null)  return false;

        return true;
    }

    public DbUser Create(string username, string password, string email, DateTime birthdate, bool isbanned,
        string phoneNumber, string lastName, string firstName, string gender, int addressId, string carPlate) {
        var user = new DbUser {
            Username = username,
            UserType = UserType.User.ToString(),
            Password = _passwordHasher.HashPwd(password),
            Email = email,
            BirthDate = birthdate,
            IsBanned = isbanned,
            PhoneNumber = phoneNumber,
            LastName = lastName,
            FirstName = firstName,
            Gender = gender,
            AddressId = addressId,
            CarPlate = carPlate
        };
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public DbUser Update(int id, string username, string password, string email, DateTime birthdate, bool isbanned,
        string phoneNumber, string lastName, string firstName, string gender, int addressId, string carPlate) {
        var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);
        if (userToUpdate == null) throw new KeyNotFoundException($"User with id {id} has not been found");
        
        userToUpdate.Username = username;
        userToUpdate.UserType = UserType.User.ToString();
        userToUpdate.Password = _passwordHasher.HashPwd(password);
        userToUpdate.Email = email;
        userToUpdate.BirthDate = birthdate;
        userToUpdate.IsBanned = isbanned;
        userToUpdate.PhoneNumber = phoneNumber;
        userToUpdate.LastName = lastName;
        userToUpdate.FirstName = firstName;
        userToUpdate.Gender = gender;
        userToUpdate.AddressId = addressId;
        userToUpdate.CarPlate = carPlate;

        _context.SaveChanges();
        return userToUpdate;
    }

    public bool Delete(int id) {
        var userToDelete = _context.Users.FirstOrDefault(u => u.Id == id);
        if (userToDelete == null) throw new KeyNotFoundException($"User with id {id} has not been found");

        _context.Users.Remove(userToDelete);
        _context.SaveChanges();
        return true;
    }
}