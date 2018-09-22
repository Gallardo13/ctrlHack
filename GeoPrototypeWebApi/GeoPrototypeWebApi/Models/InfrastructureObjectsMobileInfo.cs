using System;
namespace GeoPrototypeWebApi.Models
{
    // описание объекта для передачи в мобильное приложение
    public class InfrastructureObjectsMobileInfo
    {
        // идентификатор объекта
        public long Id { get; set; }

        // описание объекта
        public string Description { get; set; }

        // широта местоположения объекта
        public decimal Latitude { get; set; }

        // долгота месторасположения объекта
        public decimal Longitude { get; set; }
    }
}
