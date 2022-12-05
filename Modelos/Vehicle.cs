using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tacografo_DB.Modelos
{
    public class Vehicle
    {
        [BsonId]
        public ObjectId Id { get; set; }        //ID MongoDB
        public int DeviceID { get; set; }       //ID tacógrafo
        public DateTime OnTime { get; set; }    //Fecha y hora de arranque del motor
        public DateTime OffTime { get; set; }   //Fecha y hora de parada del motor
        public int Speed { get; set; }          //Velocidad del vehículo (km/h)
        public int DriveTime { get; set; }      //Tiempo durante el cual el vehículo estuvo en movimiento
        public int FuelLevel { get; set; }      //Nivel de combustible
        public bool FuelAlert { get; set; }     //Sospecha de pérdida o robo de combustible
    }
}
