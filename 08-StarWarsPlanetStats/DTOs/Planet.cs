using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StarWarsPlanetStats.DTOs;


public record Planet(
string name,
string rotation_period,
string orbital_period,
string diameter,
string climate,
string gravity,
string terrain,
string surface_water,
string population,
IReadOnlyList<string> residents,
IReadOnlyList<string> films,
DateTime created,
DateTime edited,
string url
);




