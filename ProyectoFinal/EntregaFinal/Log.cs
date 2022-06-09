using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Log
    {
        public int userId { get; }
        public int eventId { get; }
        public DateTime dateTime { get; }

        public Log(int userId, int EventId, DateTime dateTime) {
            this.userId = userId;
            this.eventId = EventId;
            this.dateTime = dateTime;
        }
    }
}
