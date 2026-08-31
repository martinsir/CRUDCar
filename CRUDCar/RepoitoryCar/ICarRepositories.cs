namespace CRUDCar.RepoitoryCar
{
    public interface ICarRepositories
    {
        bool Equals(object? obj);
        int GetHashCode();
        string? ToString();
    }
}