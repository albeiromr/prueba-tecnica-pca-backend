﻿using Domain.Commons.Abstractions;
using System;

namespace Domain.Cities;

/// <summary>
/// Represent each of the cities from where the flights depart or arrive
/// </summary>
public sealed class City : Entity
{
    public string? CityName { get; private set; }

    // this constructor is private to protect the City entity from external access
    private City(Guid id, string? cityName) : base(id)
    {
        CityName = cityName;
    }

    // this constructor is required for executing migrations with 
    // entity framework under the domain driven design architecture
    private City() { }


    /// <summary>
    /// Returns qa new instance of the City entity
    /// </summary>
    public static City Create(string? cityName)
    {
        return new City(Guid.NewGuid(), cityName);
    }
}
