namespace Adapter;

public class CityFromExternalSystem
{
    public string Name { get; }
    public string NickName { get; }
    public int Inhabitants { get; }

    public CityFromExternalSystem(
        string name,
        string nickName,
        int inhabitants)
    {
        Name = name;
        NickName = nickName;
        Inhabitants = inhabitants;
    }
}

/// <summary>
/// Adaptee
/// </summary>
public class ExternalSystem
{
    public CityFromExternalSystem GetCity() =>
        new("Antwerp", "'t Stad", 500000);
}

public class City
{
    public string FullName { get; }
    public long Inhabitants { get; }

    public City(string fullName, long inhabitants)
    {
        FullName = fullName;
        Inhabitants = inhabitants;
    }
}

/// <summary>
/// Target
/// </summary>
public interface ICityAdapter
{
    City GetCity();
}

/// <summary>
/// Adapter
/// </summary>
public class CityAdapter : ICityAdapter
{
    public ExternalSystem ExternalSystem { get; } = new();

    public City GetCity()
    {
        // call into the external system 
        CityFromExternalSystem cityFromExternalSystem = ExternalSystem.GetCity();

        // adapt the CityFromExternalCity to a City 
        return new City(
            $"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}"
            , cityFromExternalSystem.Inhabitants);
    }
}
