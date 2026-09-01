
namespace CRUDCar.Model
{
    public class Car
    {
        private int _id;
        private string _vendor;

        private string _model;

        private string _color;

        private int _kmDriven;
        private string _engineKind;
        private int _enginePower;

        private int _doors;
        private bool _towBar;
        private int _year;

        public Car()
        {
        }

        public Car(int id, string vendor, string model, string color, int kmDriven, string engineKind, int enginePower, int doors, bool towBar, int year)
        {
            _id = id;
            _vendor = vendor;
            _model = model;
            _color = color;
            _kmDriven = kmDriven;
            _engineKind = engineKind;
            _enginePower = enginePower;
            _doors = doors;
            _towBar = towBar;
            _year = year;
        }

        public int Id { get => _id; set => _id = value; }
        public string Vendor { get => _vendor; set => _vendor = value; }
        public string Model { get => _model; set => _model = value; }
        public string Color { get => _color; set => _color = value; }
        public int KmDriven { get => _kmDriven; set => _kmDriven = value; }
        public string EngineKind { get => _engineKind; set => _engineKind = value; }
        public int EnginePower { get => _enginePower; set => _enginePower = value; }
        public int Doors { get => _doors; set => _doors = value; }
        public bool TowBar { get => _towBar; set => _towBar = value; }
        public int Year { get => _year; set => _year = value; }


        public override string ToString()
        {
            return $"Id: {Id}, Vendor: {Vendor}, Model: {Model}, Color: {Color}, KmDriven: {KmDriven}, EngineKind: {EngineKind}, EnginePower: {EnginePower}, Doors: {Doors}, TowBar: {TowBar}, Year: {Year}";
        }

    }
}