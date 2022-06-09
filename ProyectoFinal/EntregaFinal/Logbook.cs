using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Logbook
    {
        private static Logbook _instance = new Logbook();

        private List<Log> logs;

        private Dictionary<int, string> EventTypes;

        private Logbook()
        {
            EventTypes = new Dictionary<int, string>()
            {
                { 101, "Simulation began" },
                { 102, "Delivery Vehicle added" },
                { 103, "Simulation ended" },
                { 104, "Order capture began" },
                { 105, "Product added to order" },
                { 106, "Order capture ended" },
                { 107, "QR created" }
            };

            logs = new List<Log>();
        }

        public static Logbook Instance
        {
            get
            {
                return _instance;
            }
        }

        public void LogEvent(int eventId)
        {
            int userId = App.currentUser;
            DateTime now =  DateTime.Now;

            logs.Add(new Log(userId, eventId, now));
        }

        public void printLogs()
        {
            foreach(Log log in logs)
            {
                Console.WriteLine(String.Format("{0}: {1} - {2}", log.userId, log.eventId, log.dateTime));
            }
        }
    }
}
