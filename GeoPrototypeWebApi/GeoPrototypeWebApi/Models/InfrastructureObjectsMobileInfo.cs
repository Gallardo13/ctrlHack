using System;
namespace GeoPrototypeWebApi.Models
{
    // описание объекта для передачи в мобильное приложение
    public class InfrastructureObjectsMobileInfo
    {
        // идентификатор объекта
        public int Id { get; set; }

        // описание объекта
        public string Description { get; set; }

        // широта местоположения объекта
        public double Latitude { get; set; }

        // долгота месторасположения объекта
        public double Longitude { get; set; }
    }
}
