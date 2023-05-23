namespace MikeAndAnt.Api.Models;

public record Package(Flight Flight, Hotel Hotel);

public record Flight(int Id);

public record Hotel(int Id);
