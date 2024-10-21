﻿using Application.UseCases.Address.Dtos;
using Application.UseCases.Car.Dtos;
using Application.UseCases.Users.Admin.Dto;
using Application.UseCases.Users.Admin.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.Users.Admin;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Users.Admin; 

public class UseCaseUpdateAdmin : IUseCaseWriter<DtoOutputAdmin, DtoInputUpdateAdmin> {
    private readonly IAdminRepository _adminRepository;
    private readonly IMapper _mapper;

    public UseCaseUpdateAdmin(IAdminRepository adminRepository, IMapper mapper) {
        _adminRepository = adminRepository;
        _mapper = mapper;
    }
    public DtoOutputAdmin Execute(DtoInputUpdateAdmin input) {
        var dbAdmin = _adminRepository.UpdateAdmin(input.Id, input.Username, input.Password, 
            input.Email, input.Birthdate, input.IsBanned, input.PhoneNumber);
        return _mapper.Map<DtoOutputAdmin>(dbAdmin);
    }
}