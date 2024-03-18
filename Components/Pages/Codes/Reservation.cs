using System;

namespace Reserve.Components.Pages.Codes
{
    internal partial class Reservation
    {
        // Constant for record size
        public const int RECORD_SIZE = 201;

        // Fields for reservation details
        private string code;            // Reservation code
        private string flightCode;      // Flight code
        private string airline;         // Airline
        private string name;            // Passenger name
        private string citizenship;     // Passenger citizenship
        private double cost;            // Reservation cost
        private string active;          // Reservation status
        private string reservationCode; // Reservation code
        private Flight flight;          // Associated flight

        // Default constructor
        public Reservation()
        {
        }

        // Constructor with parameters
        public Reservation(string code, string flightCode, string airline, double cost, string name, string citizenship, string active)
        {
            this.code = code;
            this.flightCode = flightCode;
            this.airline = airline;
            this.name = name;
            this.citizenship = citizenship;
            this.cost = cost;
            this.active = active;
        }

        // Constructor with parameters
        public Reservation(string reservationCode, Flight flight, string name, string citizenship)
        {
            this.reservationCode = reservationCode;
            this.flight = flight;
            this.name = name;
            this.citizenship = citizenship;
        }

        // Properties for accessing fields
        public string Code { get => code; set => code = value; }
        public string FlightCode { get => flightCode; set => flightCode = value; }
        public string Airline { get => airline; set => airline = value; }
        public string Name { get => name; set => name = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public double Cost { get => cost; set => cost = value; }
        public string Active { get => active; set => active = value; }

        // Method to set passenger name
        public void SetName(string name)
        {
            // Check for null or empty name
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            this.name = name;
        }

        // Method to set passenger citizenship
        public void SetCitizenship(string citizenship)
        {
            // Check for null or empty citizenship
            if (string.IsNullOrEmpty(citizenship))
            {
                throw new Exception(); // Exception type should be specified
            }

            this.citizenship = citizenship;
        }

        // Method to return reservation details as string
        public string ToString()
        {
            return $"{Code}, {FlightCode}, {Airline}, {Cost}, {Name}, {Citizenship}, {Active}";
        }
    }
}
