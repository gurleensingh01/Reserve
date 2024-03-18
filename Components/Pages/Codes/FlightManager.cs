using System;
using System.Collections.Generic;
using System.IO;

namespace Reserve.Components.Pages.Codes
{
    internal class FlightManager
    {
        // Constants for weekdays
        public static string WEEKDAY_ANY = "Any";
        public static string WEEKDAY_SUNDAY = "Sunday";
        public static string WEEKDAY_MONDAY = "Monday";
        public static string WEEKDAY_TUESDAY = "Tuesday";
        public static string WEEKDAY_WEDNESDAY = "Wednesday";
        public static string WEEKDAY_THURSDAY = "Thursday";
        public static string WEEKDAY_FRIDAY = "Friday";
        public static string WEEKDAY_SATURDAY = "Saturday";

        // File paths for data
        public static string FLIGHTS_TEXT = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\flights.csv");
        public static string AIRPORTS_TEXT = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\airports.csv");

        // Lists to store flights and airports
        public static List<Flight> flights = new List<Flight>();
        public static List<string> airports = new List<string>();

        // Default constructor to populate data
        public FlightManager()
        {
            populateAirports();
            populateFlights();
        }

        // Method to get all airports
        public List<string> getAirports()
        {
            return airports;
        }

        // Method to get all flights
        public static List<Flight> getFlights()
        {
            return flights;
        }

        // Method to find airport by code
        public string findAirportByCode(string code)
        {
            foreach (string airport in airports)
            {
                if (airport.Equals(code))
                    return airport;
            }
            return null;
        }

        // Method to find flight by code
        public static Flight findFlightByCode(string code)
        {
            foreach (Flight flight in flights)
            {
                if (flight.Code.Equals(code))
                    return flight;
            }
            return null;
        }

        // Method to find flights based on criteria
        public static List<Flight> findFlights(string from, string to, string weekday)
        {
            List<Flight> found = new List<Flight>();

            foreach (Flight flight in flights)
            {
                if ((weekday.Equals(WEEKDAY_ANY) || flight.Weekday.Equals(weekday)) &&
                    (to.Equals(WEEKDAY_ANY) || flight.To.Equals(to)) &&
                    (from.Equals(WEEKDAY_ANY) || flight.From.Equals(from)))
                {
                    found.Add(flight);
                }
            }
            return found;
        }

        // Method to populate flights from CSV file
        private void populateFlights()
        {
            flights.Clear();
            try
            {
                int counter = 0;
                Flight flight;
                foreach (string line in File.ReadLines(FLIGHTS_TEXT))
                {
                    string[] parts = line.Split(",");

                    string code = parts[0];
                    string airline = parts[1];
                    string from = parts[2];
                    string to = parts[3];
                    string weekday = parts[4];
                    string time = parts[5];
                    int seatsAvailable = short.Parse(parts[6]);
                    double pricePerSeat = double.Parse(parts[7]);
                    string fromAirport = findAirportByCode(from);
                    string toAirport = findAirportByCode(to);

                    try
                    {
                        flight = new Flight(code, airline, fromAirport, toAirport, weekday, time, seatsAvailable, pricePerSeat);
                        flights.Add(flight);
                    }
                    catch (Exception e)//InvalidFlightCodeException
                    {
                        // Handle exception
                    }
                    counter++;
                }
            }
            catch (Exception e)
            {
                // Handle exception
            }
        }

        // Method to populate airports from CSV file
        private void populateAirports()
        {
            try
            {
                int counter = 0;
                foreach (string line in File.ReadLines(AIRPORTS_TEXT))
                {
                    string[] parts = line.Split(",");

                    string code = parts[0];
                    string name = parts[1];
                    airports.Add(code);

                    counter++;
                }
            }
            catch (Exception e)
            {
                // Handle exception
            }
        }
    }
}
