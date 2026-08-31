using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDCar.Model
{
    public class Car : ICar
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
    }
}