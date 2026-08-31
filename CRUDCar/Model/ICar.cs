namespace CRUDCar.Model
{
    public interface ICar
    {
        string Color { get; set; }
        int Doors { get; set; }
        string EngineKind { get; set; }
        int EnginePower { get; set; }
        int Id { get; set; }
        int KmDriven { get; set; }
        string Model { get; set; }
        bool TowBar { get; set; }
        string Vendor { get; set; }
        int Year { get; set; }
    }
}