using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    internal abstract class DeliveryVehicle
    {
        public int VehicleID { get; set; }
        public float maxCapacity  { get; set; }
        public float curCapacity { get; set; }

        public DeliveryVehicle(float weightCapacity)
        {
            //this.VehicleID = VehicleID;
            this.maxCapacity = weightCapacity;
            curCapacity = 0.0f;
        }

        public void FullLoad()
        {
            curCapacity = maxCapacity;
        }

        public void Deliver(float amount)
        {
            if(this.CanDeliver(amount)) curCapacity -= amount;
        }

        public bool CanDeliver(float amount)
        {
            if (curCapacity >= amount) return true;
            return false;
        }
    }
}
