/*
 * Створіть власну збірку на основі прикладу збірки CarLibrary  з уроку,  збірка буде використана для
 * роботи з перетворювачем температури. 
 */

namespace TemperatureConverterLibrary
{
    public class Temperature
    {
        private decimal _temperature;

        public decimal Celsius
        {
            get 
            { 
                return _temperature; 
            }
            set
            {
                if (value < -273.15m)
                {
                    throw new ArgumentOutOfRangeException($"{value} is less than absolute zero.");
                }
                _temperature = value;
            }
        }

        public decimal Fahrenheit
        {
            get { return _temperature * 9 / 5 + 32; }
        }

        public decimal Kelvin
        {
            get { return _temperature + 273.15m; }
        }

        public decimal CelsiusToFahrenheit(decimal value)
        { 
            Celsius = value;
            return Fahrenheit;
        }

        public decimal CelsiusToKelvin(decimal value)
        {
            Celsius = value;
            return Kelvin;
        }

        public decimal FahrenheitToKelvin(decimal value)
        {
            Celsius = (value - 32) * 5 / 9;
            return Kelvin;
        }

        public decimal FahrenheitToCelsius(decimal value)
        {
            Celsius = (value - 32) * 5 / 9;
            return Celsius;
        }

        public decimal KelvinToFahrenheit(decimal value)
        {
            Celsius = value - 273.15m;
            return Fahrenheit;
        }

        public decimal KelvinToCelsius(decimal value)
        {
            Celsius = value - 273.15m;
            return Celsius;
        }
    }
}
