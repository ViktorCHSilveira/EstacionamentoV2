using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
    public class ParkingFloor {

        public Guid Id { get; set; }
        public Guid EstablishimentId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime CheckInDt { get; set; }
        public DateTime? CheckOutDt { get; set; }
        public int HoursPaydInAdvance { get; set; }
        public bool Payed { get; set; }
    }
}
